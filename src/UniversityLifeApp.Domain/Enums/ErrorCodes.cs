using System;
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

        [Description("Password is incorrect")]
        PASSWORD_IS_INCORRECT = 1_1_0,

        [Description("User is already exist.")]
        USER_IS_ALREADY_EXIST = 1_0_1,

        [Description("There are some validations error.")]
        VALIDATION_ERROR = 2_0_0,

        [Description("teterte")]
        NullReferances_Error = 3_0_0,

        [Description("Internal server error occured")]
        INTERNAL_SERVER_ERROR = 5_0_0,



        [Description("The data you wanted to delete could not be found.")]
        DELETE_ERROR = 2_1_0,

        [Description("This item already exist in your wishlist")]
        WISHLIST_IS_ALREADY_EXIST = 4_0_0,



    }
}
