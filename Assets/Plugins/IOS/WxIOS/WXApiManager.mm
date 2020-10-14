#import "WXApiManager.h"
#import "WXSDK/WXApiObject.h"
#import "Unity/UnityInterface.h"
@implementation WXApiManager

+(instancetype) shareManager
{
    static dispatch_once_t onceToken;
    static WXApiManager *instance;
    dispatch_once(&onceToken, ^{
        instance = [[WXApiManager alloc] init];
    });
    return instance;
}

-(void) onReq:(BaseReq *)req {}

-(void) onResp:(BaseResp *)resp
{
    //NSLog(@"errcode %d %@",resp.errCode,((SendAuthResp*)resp).code);
    NSString* data=@"";
    if([resp isKindOfClass:[SendAuthResp class]]){
        SendAuthResp* temp=(SendAuthResp*)resp;
        data=[NSString stringWithFormat:@"%d,%d,%@",resp.type,resp.errCode,temp.code];
    }
    
     UnitySendMessage("_WxMsgRecever", "onRecv",[data UTF8String]);
}
@end
