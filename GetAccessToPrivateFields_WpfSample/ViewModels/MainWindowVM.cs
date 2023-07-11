﻿using GetAccessToPrivateFields_WpfSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GetAccessToPrivateFields_WpfSample.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        //Models.SecretModel _secretModel = new Models.SecretModel();
        public MainWindowVM() { OnStartup(); }
        private void OnStartup()
        {
            SetResult1_FieldInfoMethod();
            Result2 = GetAccessToPrivateFields_Sample2();
            Result3 = GetAccessToPrivateFields_Sample3();
        }
        #region поля для заполнения wpf 
        private string _result1 = "sample1";
        public string Result1 { get { return _result1; } set { _result1 = value; OnPropertyChanged("Result1"); } }

        private string _result2 = "sample2";
        public string Result2 { get { return _result2; } set { _result2 = value; OnPropertyChanged("Result2"); } }

        private string _result3 = "sample3";
        public string Result3 { get { return _result3; } set { _result3 = value; OnPropertyChanged("Result3"); } }
        #endregion

        #region Example 1 _ FieldInfo
        private void SetResult1_FieldInfoMethod(/*SecretModel secretModel*/)
        {
            Models.SecretModel _secretModel = new Models.SecretModel();
            string result = string.Empty;
            FieldInfo fieldInfo = typeof(SecretModel).GetField("_secret", BindingFlags.Instance | BindingFlags.NonPublic);
            if (fieldInfo != null)
            {
                result = (string)fieldInfo.GetValue(_secretModel);
            }
           // return result;
           Result1 = result;
        }
        #endregion

        #region Example 2 _ ExpressionTrees
        private static string GetAccessToPrivateFields_Sample2(/*SecretClass privateClassInstance*/)
        {
            Models.SecretModel _secretModel = new Models.SecretModel();
            ParameterExpression keeperArg = Expression.Parameter(typeof(SecretModel), $"{_secretModel}"); // argument = SecretModel _secretModel
            Expression secretAncessor = Expression.Field(keeperArg, "_secret"); //_secretModel._secret
            var lambda = Expression.Lambda<Func<SecretModel, string>>(secretAncessor, keeperArg);
            var func = lambda.Compile(); // return result = _secretModel._secret
            return func(_secretModel);
        }
        #endregion

        #region Example 3 _ SecretModel Nested Class
        private string GetAccessToPrivateFields_Sample3( )
        {
            Models.SecretModel _secretModel = new SecretModel(); 
            Models.SecretModel.SecretTokenSource secretTokenSource = new SecretModel.SecretTokenSource(_secretModel);
            return secretTokenSource.GetSecret();
        }

        #endregion

    }
}