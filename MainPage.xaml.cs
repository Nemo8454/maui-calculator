using System.Data;
using System;
namespace CalcMaui
{
    public partial class MainPage : ContentPage
    {
        public string expressionStr = "";
        

        public MainPage()
        {
            InitializeComponent();
        }

        #region "录入运算符,及"%"和".""
        private void btnNumber_Clicked(object sender, EventArgs e)
        {
            if(sender is Button button)
                expressionStr += button.Text;
            lbExpression.Text = expressionStr;
        }
        #endregion


        #region "数字键录入"
        private void btnSymbol_Clicked(object sender, EventArgs e)
        {
            if(sender is Button button)
                if (button.CommandParameter != null)
                {
                    string customValue = button.CommandParameter.ToString();
                    expressionStr += customValue;
                }
                else
                    expressionStr += button.Text;
            lbExpression.Text = expressionStr;
        }
        #endregion


        #region "=  显示计算结果"
        private void btnRes_Clicked(object sender, EventArgs e)
        {
            lbResult.Text = EvaluateExpression(expressionStr).ToString();
        }
        /// <summary>
        /// 用于计算string类型的表达式的值
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        static double EvaluateExpression(string expression)
        {
            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(string), expression);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string)row["expression"]);
        }
        #endregion


        #region "CE  实现清空所有"
        private void btnCE_Clicked(object sender, EventArgs e)
        {
            expressionStr = "";
        }
        #endregion
    }
}