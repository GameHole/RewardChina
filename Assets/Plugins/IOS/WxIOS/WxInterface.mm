#import <Foundation/Foundation.h>
#import "WXSDK/WXApi.h"
extern  "C"{
//这是向微信终端注册你的appid
void _registerApp(char* appid,char* url)
{
    NSString *weichatId = [NSString stringWithFormat:@"%s", appid];
    NSString *link = [NSString stringWithFormat:@"%s", url];
    [WXApi registerApp:weichatId universalLink:link];
}

//登录
void _wechatLogin(char* message)
{
    SendAuthReq* req = [[SendAuthReq alloc] init];
    req.scope = @"snsapi_userinfo";
    req.state = [NSString stringWithFormat:@"%s", message];
    [WXApi sendReq:req completion:nil];
}

//
bool _isWechatInstalled()
{
    return [WXApi isWXAppInstalled];
}

}
