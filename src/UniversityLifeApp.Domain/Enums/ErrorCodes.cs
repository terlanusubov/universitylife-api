﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLifeApp.Domain.Enums
{
    public enum ErrorCodes
    {
        [Description("Email or password is not correct")]
        EMAIL_OR_PASSWORD_IS_NOT_CORRECT = 1_0_0,

        [Description("User is already exist.")]
        USER_IS_ALREADY_EXIST = 1_0_1,

        [Description("There are some validations error.")]
        VALIDATION_ERROR = 2_0_0,
        [Description("teterte")]
        NullReferances_Error = 3_0_0

    }
}
