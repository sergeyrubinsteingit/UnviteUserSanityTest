using Aspose.Pdf.Operators;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Test.GlobalClasses
{
    class TestData
    {

        public static string testValue;


        [Flags]
        public enum KeyWords
        {
            HOST_QA, URL_QA, URL_USERS, ACTOR_QA, ACTOR_PROD, USER_NAME, USER_MAIL_INPUT, USER_PASS_INPUT, PASS_QA, 
            PASS_PROD, SETUP_MFA_BUTTON, SMS_LOGIN_FIELD, MOMA_LOGIN_FIELD, SIGNIN_BUTTON, DONT_TRUST_BUTTON,
            COOKIE_BAR, COOKIE_CONFIRM_BUTTON, FILTER_CONTAINER, MENU_THEME_ICON, CLOSE_POPUP, MENU_ADMINISTRATION_LINK,
            MENU_SYSTEM_USERS_LINK, CREATE_USER_BUTTON, INVITE_USER_WINDOW, INVITE_USER_IFRAME, ACTOR_ID_INPUT,
            INVITE_USER_TITLE, INVITE_USER_JOB_FUNCTION, INVITE_USER_LOGIN, INVITE_USER_EMAIL, INVITE_USER_VERIFY_EMAIL, 
            INVITE_USER_JOB_TITLE_DESCR, INVITE_USER_JOB_FUNCTION_DESCR, INVITE_USER_LOGIN_DESCR, INVITE_USER_MAIL, 
            INVITE_USER_MAIL_VERIFIC, INVITE_USER_NEXT_BUTTON, INVITE_USER_PREVIUOS_BUTTON, INVITE_USER_INVITE_BUTTON, 
            INVITE_USER_AVAILABLE_ROLES, INVITE_USER_ADMIN_ROLE, INVITE_USER_VMO_MANAGER_BOX, INVITE_USER_WEB_SCREEN_BOX,
            INVITE_USER_LOG_BOX, INVITE_USER_EDITWRITE_BOX, INVITE_USER_EVENT_CATEGORY, INVITE_USER_GROUP_CATEGORY,
            INVITE_USER_ALERTS_FILTER, INVITE_USER_ALERTS_FILTER_BTN,
            INVITE_USER_ALERTS_SMS_BOX, NOTIF_SUCCESS, NOTIF_ERROR, INVITE_USER_CAPTCHA_BOX, INVITE_USER_CAPTCHA_CHECKMARK, 
            INVITE_USER_CONTINUE_BUTTON, 
            INVITE_USER_CAPTCHA_SPINNER, INVITE_USER_USER_PASSWORD_FIELD, INVITE_USER_PASSWORD_MATCH, INVITE_USER_IS_TERMS_AND_CONDITIONS, 
            INVITE_USER_PASSWORD, INVITE_USER_USER_FIRSTNAME,
            INVITE_USER_USER_LASTNAME, INVITE_USER_ADDRESS_TEXTAREA, INVITE_USER_FIRSTNAME, INVITE_USER_LASTNAME, 
            INVITE_USER_COUNTRY_ID_INPUT, INVITE_USER_COUNTRY_CODE, INVITE_USER_MOBILE, INVITE_USER_INVALID_MOBILE, 
            INVITE_USER_INVALID_MOBILE_MSG,INVITE_USER_SMS_BUTTON, INVITE_USER_VALIDATOR, INVITE_USER_MFA_SMS_RBUTTON,
        }


        public static readonly Dictionary<KeyWords, string> TestKeyValues = new Dictionary<KeyWords, string>()
            {
                {KeyWords.HOST_QA, "qa.nayax.com"},
                {KeyWords.URL_QA, "https://qa.nayax.com/core/LoginPage.aspx"},
                {KeyWords.URL_USERS, "https://qa.nayax.com/core/public/f?model=administration/Users"},
                {KeyWords.ACTOR_QA, "sergey_EatDrinkSleepDie57"},
                {KeyWords.USER_NAME, "sergeyr"},
                {KeyWords.PASS_QA, "rubi69QA0******"},
                {KeyWords.PASS_PROD, "rubi69production-3*"},
                {KeyWords.USER_MAIL_INPUT, "input#txtUser"},
                {KeyWords.USER_PASS_INPUT, "input#txtPassword"},
                {KeyWords.SETUP_MFA_BUTTON, "input#setupMfa"},
                {KeyWords.SMS_LOGIN_FIELD, "input#second_factor_option_sms_input"},
                {KeyWords.MOMA_LOGIN_FIELD, "input#second_factor_option_totp_input"},
                {KeyWords.SIGNIN_BUTTON, "input#signin"},
                {KeyWords.DONT_TRUST_BUTTON, "input#trustDeviceNever"},
                {KeyWords.COOKIE_BAR, "div#onetrust-banner-sdk"},
                {KeyWords.COOKIE_CONFIRM_BUTTON, "button#onetrust-accept-btn-handler"},
                {KeyWords.FILTER_CONTAINER, "div#filter_container"},
                {KeyWords.MENU_THEME_ICON, "div#menu_new_core"},
                {KeyWords.CLOSE_POPUP, "span.sticky-button-close"},
                {KeyWords.MENU_ADMINISTRATION_LINK, "//img[@src=\"Images/Menu/administration.png\"]"},
                {KeyWords.MENU_SYSTEM_USERS_LINK, "//*[@id=\"mainMenu_mn_active\"]/div/ul/li[2]"},
                {KeyWords.CREATE_USER_BUTTON, "div#panel_user_create_btn"},
                {KeyWords.INVITE_USER_WINDOW, "div#uiMainTD"},
                {KeyWords.INVITE_USER_IFRAME, "//*[@id=\"userInviteWindow\"]/iframe"},
                {KeyWords.ACTOR_ID_INPUT, "//*[@id=\"actor_id_input\"]"},
                {KeyWords.INVITE_USER_TITLE, "//*[@id=\"b-user_title\"]"},
                {KeyWords.INVITE_USER_JOB_FUNCTION, "input#job_function_input"},
                {KeyWords.INVITE_USER_LOGIN, "input#ad_name"},
                {KeyWords.INVITE_USER_EMAIL, "input#user_email"},
                {KeyWords.INVITE_USER_VERIFY_EMAIL, "input#verify_user_email"},
                {KeyWords.INVITE_USER_JOB_TITLE_DESCR, "testUser"},
                {KeyWords.INVITE_USER_JOB_FUNCTION_DESCR, "//*[@id=\"job_function\"]/div[2]/ul/li[2]"},
                {KeyWords.INVITE_USER_LOGIN_DESCR, "autoUser"},
                {KeyWords.INVITE_USER_MAIL, "sergeyr@nayax.com"},
                {KeyWords.INVITE_USER_MAIL_VERIFIC, "SERGEYR@nayax.com"},
                {KeyWords.INVITE_USER_NEXT_BUTTON, "button#next"},
                {KeyWords.INVITE_USER_PREVIUOS_BUTTON, "button#prev"},
                {KeyWords.INVITE_USER_INVITE_BUTTON, "button#save"},
                {KeyWords.INVITE_USER_AVAILABLE_ROLES, "input.mc-search-input.form-control.form-control-sm[0]"},
                {KeyWords.INVITE_USER_ADMIN_ROLE, "//*[@id=\"uiMainTD\"]/div/div[1]/div[3]/div/div[1]/div[2]/div[2]/label"},
                {KeyWords.INVITE_USER_VMO_MANAGER_BOX, "span.custom-control-input[7]" },
                {KeyWords.INVITE_USER_WEB_SCREEN_BOX, "//*[@id=\"menuTree_0\"]/i"},
                {KeyWords.INVITE_USER_LOG_BOX, "//*[@id=\"menuTree_75\"]/a/input"},
                {KeyWords.INVITE_USER_EDITWRITE_BOX, "//*[@id=\"b-\"]"},
                {KeyWords.INVITE_USER_EVENT_CATEGORY, "//*[@id=\"event_category_id_input\"]"},
                {KeyWords.INVITE_USER_GROUP_CATEGORY, "//*[@id=\"group_category_id_input\"]"},
                {KeyWords.INVITE_USER_ALERTS_FILTER, "//*[@id=\"search_event\"]"},
                {KeyWords.INVITE_USER_ALERTS_FILTER_BTN, "//*[@id=\"uiMainTD\"]/div/div[1]/div[6]/div/div[1]/div[1]/div[3]/button"},
                {KeyWords.INVITE_USER_ALERTS_SMS_BOX, "//*[@id=\"userRule_table\"]/div[3]/table/tbody/tr[1]/td[4]/input"},
                {KeyWords.NOTIF_SUCCESS, "div.notification.success"},
                {KeyWords.NOTIF_ERROR, "div.notification.error"},
                {KeyWords.INVITE_USER_CAPTCHA_BOX, "span#recaptcha-anchor"},
                {KeyWords.INVITE_USER_CAPTCHA_CHECKMARK, "div.recaptcha-checkbox-checkmark"},
                {KeyWords.INVITE_USER_CAPTCHA_SPINNER, "div.recaptcha-checkbox-spinner"},
                {KeyWords.INVITE_USER_CONTINUE_BUTTON, "input#register"},
                {KeyWords.INVITE_USER_USER_PASSWORD_FIELD, "input#user_password"},
                {KeyWords.INVITE_USER_PASSWORD_MATCH, "input#user_password_match"},
                {KeyWords.INVITE_USER_PASSWORD, "rubiserg1969testUser"},
                {KeyWords.INVITE_USER_IS_TERMS_AND_CONDITIONS, "input#is_terms_and_conditions"},
                {KeyWords.INVITE_USER_USER_FIRSTNAME, "input#user_firstname"},
                {KeyWords.INVITE_USER_USER_LASTNAME, "input#user_lastname"},
                {KeyWords.INVITE_USER_FIRSTNAME, "Marie"},
                {KeyWords.INVITE_USER_LASTNAME, "Charge-free"},
                {KeyWords.INVITE_USER_ADDRESS_TEXTAREA, "input#user_address_textarea"},
                {KeyWords.INVITE_USER_COUNTRY_ID_INPUT, "input#country_id_input"},
                {KeyWords.INVITE_USER_COUNTRY_CODE, "972"},
                {KeyWords.INVITE_USER_INVALID_MOBILE, "INVALID_MOBILE"},
                {KeyWords.INVITE_USER_INVALID_MOBILE_MSG, "Please insert a valid Phone"},
                {KeyWords.INVITE_USER_MOBILE, "545898076"},
                {KeyWords.INVITE_USER_SMS_BUTTON, "button#send_sms_btn"},
                {KeyWords.INVITE_USER_VALIDATOR, "input#input_code_0"},
                {KeyWords.INVITE_USER_MFA_SMS_RBUTTON, "input.radioLabel[1]"},
            };        
    }
}