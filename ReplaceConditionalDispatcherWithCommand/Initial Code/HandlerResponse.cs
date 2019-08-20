﻿using System;
using System.Text;

namespace ReplaceConditionalDispatcherWithCommand.Initial_Code
{
    public class HandlerResponse
    {
        private StringBuilder _stringBuilder;
        private String _allWorkshopsStylesheet;

        public HandlerResponse()
        {
        }

        public HandlerResponse(StringBuilder stringBuilder, String allWorkshopsStylesheet)
        {
            this._stringBuilder = stringBuilder;
            this._allWorkshopsStylesheet = allWorkshopsStylesheet;
        }
    }
}