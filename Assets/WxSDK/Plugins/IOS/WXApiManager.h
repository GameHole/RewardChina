#import <Foundation/Foundation.h>
#import "WXSDK/WXApi.h"

@interface WXApiManager : UIResponder<UIApplicationDelegate, WXApiDelegate>

+ (instancetype)shareManager;

@end
