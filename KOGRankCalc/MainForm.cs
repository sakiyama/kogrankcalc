using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace KOGRankCalc
{
    public partial class MainForm : Form
    {
        private BindingSource bindingSource1 = new BindingSource();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// ドラッグ&ドロップ開始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainDataGridView_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //ファイル以外は受け付けない
                e.Effect = DragDropEffects.None;
                return;
            }

            //ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
            e.Effect = DragDropEffects.Copy;

        }

        /// <summary>
        /// ドラッグ&ドロップ中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainDataGridView_DragDrop(object sender, DragEventArgs e)
        {
            //コントロール内にドロップされたとき実行される
            //ドロップされたすべてのファイル名を取得する
            var fileName =
                (string[])e.Data.GetData(DataFormats.FileDrop, false);

            var roundCnt = fileNameDataSetBindingSource.Count;

            //取得したファイル数分取得
            foreach (var fName in fileName)
            {
                var tmp = fileNameDataSetBindingSource.List.OfType<FileNameDataSet>().ToList().Find(f => f.fileFullPath == fName);
                if (null != tmp) { continue; }

                fileNameDataSetBindingSource.Add(new FileNameDataSet(++roundCnt, fName));
            }
        }

        /// <summary>
        /// リストの行毎の削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            var rowCount = MainDataGridView.RowCount;
            //削除
            if (e.KeyCode == Keys.Delete && 0 < MainDataGridView.RowCount)
            {
                MainDataGridView.Rows.RemoveAt(MainDataGridView.CurrentCell.RowIndex);
            }

        }

        /// <summary>
        /// 処理前チェック
        /// </summary>
        /// <returns></returns>
        private bool ExecValidate()
        {
            if (String.IsNullOrEmpty(FileNameTxtBox.Text))
            {
                MessageBox.Show(
                    "出力先ファイル名を指定してください。",
                    "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
                return false;
            }

            //1つ以上のデータがなければランキングは出せない
            if (fileNameDataSetBindingSource.List.Count <= 1)
            {
                MessageBox.Show(
                    "1つ以上のデータを指定してください。\r\nドラッグアンドドロップでリストにデータを入れてください",
                    "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Run_Click(object sender, EventArgs e)
        {
            //処理前チェック
            if (bool.Equals(false, ExecValidate()))
            {
                return;
            }

            var ranking = new Ranking();
            try
            {
                //全結果データ読み込み
                foreach (FileNameDataSet row in fileNameDataSetBindingSource.List)
                {
                    ranking.Import(row.fileFullPath);
                }

                ranking.Export(FileNameTxtBox.Text);

            }
            catch (EngineException ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "例外", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        /// <summary>
        /// ファイルダイアログ表示
        /// </summary>
        /// <returns></returns>
        private string ShowFileDialog()
        {
            //SaveFileDialogクラスのインスタンスを作成
            var sfd = new SaveFileDialog();

            //はじめのファイル名を指定する
            sfd.FileName = "";

            //はじめに表示されるフォルダを指定する
            sfd.InitialDirectory = @"C:\";

            //[ファイルの種類]に表示される選択肢を指定する
            sfd.Filter =
                "CSVファイル(*.csv)|*.csv|すべてのファイル(*.*)|*.*";

            //[ファイルの種類]ではじめに
            //「CSVファイル」が選択されているようにする
            sfd.FilterIndex = 1;

            //タイトルを設定する
            sfd.Title = "ランキング保存先のファイルを選択してください";

            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            sfd.RestoreDirectory = true;

            //既に存在するファイル名を指定したとき警告する
            sfd.OverwritePrompt = false;

            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            sfd.CheckPathExists = true;

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                //選択されたファイル名を返却
                return sfd.FileName;
            }
            return null;
        }

        /// <summary>
        /// リストからデータを全消去
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            MainDataGridView.Rows.Clear();
        }

        /// <summary>
        /// 出力ファイル名テキストボックスをダブルクリックした際に表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileNameTxtBox_DoubleClick(object sender, EventArgs e)
        {
            string outFilePath = null;

            outFilePath = ShowFileDialog();
            if (null != outFilePath)
            {
                FileNameTxtBox.Text = outFilePath;
            }
        }

    }
}
