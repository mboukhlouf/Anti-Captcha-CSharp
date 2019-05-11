using System;
using System.Collections.Generic;
using System.Text;

namespace AntiCaptcha
{
    public enum Queue
    {
        STD_IMAGE_TO_TEXT_EN = 1,
        STD_IMAGE_TO_TEXT_RU = 2,
        RECAPTCHA_NOCAPTCHA_TASKS = 5,
        RECAPTCHA_PROXYLESS_TASK = 6,
        FUN_CAPTCHA = 7,
        FUN_CAPTCHA_PROXYLESS = 10
    }
}
