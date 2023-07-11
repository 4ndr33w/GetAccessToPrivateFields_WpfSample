using GetAccessToPrivateFields_WpfSample.Models;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace GetAccessToPrivateFields_WpfSample.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        public MainWindowVM() { OnStartup(); }
        private void OnStartup()
        {
            SetResult1_FieldInfoMethod();
            Result2 = GetAccessToPrivateFields_Sample2();
            Result3 = GetAccessToPrivateFields_Sample3();
            SetResult4_FieldInfoMethodStatic();
            SetResult5_FieldInfoMethodStaticClass();
        }
        #region поля для заполнения wpf 

        private string _timeSpan1;
        public string TimeSpan1 { get { return _timeSpan1; } set { _timeSpan1 = value; OnPropertyChanged("TimeSpan1"); } }

        private string _timeSpan2;
        public string TimeSpan2 { get { return _timeSpan2; } set { _timeSpan2 = value; OnPropertyChanged("TimeSpan2"); } }

        private string _timeSpan3;
        public string TimeSpan3 { get { return _timeSpan3; } set { _timeSpan3 = value; OnPropertyChanged("TimeSpan3"); } }

        private string _timeSpan4;
        public string TimeSpan4 { get { return _timeSpan4; } set { _timeSpan4 = value; OnPropertyChanged("TimeSpan4"); } }

        private string _timeSpan5;
        public string TimeSpan5 { get { return _timeSpan5; } set { _timeSpan5 = value; OnPropertyChanged("TimeSpan5"); } }

        private string _result1 = "sample1";
        public string Result1 { get { return _result1; } set { _result1 = value; OnPropertyChanged("Result1"); } }

        private string _result2 = "sample2";
        public string Result2 { get { return _result2; } set { _result2 = value; OnPropertyChanged("Result2"); } }

        private string _result3 = "sample3";
        public string Result3 { get { return _result3; } set { _result3 = value; OnPropertyChanged("Result3"); } }

        private string _result4 = "sample4";
        public string Result4 { get { return _result4; } set { _result4 = value; OnPropertyChanged("Result4"); } }

        private string _result5 = "sample5";
        public string Result5 { get { return _result5; } set { _result5 = value; OnPropertyChanged("Result5"); } }
        #endregion

        #region Example 1 _ FieldInfo
        private void SetResult1_FieldInfoMethod()
        {
            var startTime = DateTime.Now;
            Models.SecretModel _secretModel = new Models.SecretModel();
            string result = string.Empty;
            FieldInfo fieldInfo = typeof(SecretModel).GetField("_secret", BindingFlags.Instance | BindingFlags.NonPublic);
            if (fieldInfo != null)
            {
                result = (string)fieldInfo.GetValue(_secretModel);
            }
            var endTime = DateTime.Now;
            TimeSpan1 = TimeCounterMethod(startTime, endTime);
            Result1 = result;
        }
        #endregion

        #region Example 2 _ ExpressionTrees
        private string GetAccessToPrivateFields_Sample2()
        {
            var startTime = DateTime.Now;
            Models.SecretModel _secretModel = new Models.SecretModel();
            ParameterExpression keeperArg = Expression.Parameter(typeof(SecretModel), $"{_secretModel}"); // argument = SecretModel _secretModel
            Expression secretAncessor = Expression.Field(keeperArg, "_secret"); //_secretModel._secret
            var lambda = Expression.Lambda<Func<SecretModel, string>>(secretAncessor, keeperArg);
            var func = lambda.Compile(); // return result = _secretModel._secret
            var endTime = DateTime.Now;
            TimeSpan2 = TimeCounterMethod(startTime, endTime);
            return func(_secretModel);
        }
        #endregion

        #region Example 3 _ SecretModel Nested Class
        private string GetAccessToPrivateFields_Sample3( )
        {
            var startTime = DateTime.Now;
            Models.SecretModel _secretModel = new SecretModel(); 
            Models.SecretModel.SecretTokenSource secretTokenSource = new SecretModel.SecretTokenSource(_secretModel);
            var endTime = DateTime.Now;
            TimeSpan3 = TimeCounterMethod(startTime, endTime);
            return secretTokenSource.GetSecret();
        }

        #endregion

        #region Example 4 _ FieldInfo
        private void SetResult4_FieldInfoMethodStatic()
        {
            var startTime = DateTime.Now;
            SecretModel secretModel = new SecretModel();
            string result = string.Empty;
            FieldInfo[] fieldInfo = typeof(SecretModel).GetFields(BindingFlags.NonPublic | BindingFlags.Static);
            if (fieldInfo != null)
            {
                result = (string)fieldInfo[0].GetValue(secretModel);
                Result4 = result;
                var endTime = DateTime.Now;
                TimeSpan4 = TimeCounterMethod(startTime, endTime);
            }          
        }
        #endregion

        #region Example 5 _ FieldInfo - Static Class
        private void SetResult5_FieldInfoMethodStaticClass()
        {
            var startTime = DateTime.Now;
            string result = string.Empty;
            var fieldInfo = typeof(StaticSecretModel).GetField("_staticSecret", BindingFlags.NonPublic | BindingFlags.Static);
            if (fieldInfo != null)
            {
                result = (string)fieldInfo.GetValue(null);
                Result5 = result;
                var endTime = DateTime.Now;
                TimeSpan5 = TimeCounterMethod(startTime, endTime);
            }
        }
        #endregion

        #region TimeCounterMethod
        private string TimeCounterMethod(DateTime startTime, DateTime endTime)
        {
            var timeSpan = (double)(endTime - startTime).TotalMilliseconds;
            return $"{timeSpan} ms";
        }

        #endregion
    }
}
