//
//  NSError+MDPError.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 2/3/16.
//  Copyright © 2016 Microsoft. All rights reserved.
//

#import <Foundation/Foundation.h>

#pragma mark  - MDPHTTPErrorMessageCodeType
typedef NS_ENUM(NSInteger, MDPHTTPErrorStatusCode) {
    MDPHTTPErrorStatusCodePreconditionFailed       = 412, // Request failed: precondition failed (412)
};

/****
 
 [Description("Fan is too young")]
 FanIsTooYoung = 0,
 [Description("Fan age is not defined")]
 FanAgeIsNotDefined = 1,
 [Description("Fan does not have enough points")]
 FanDoesNotHaveEnoughPoints = 2,
 [Description("Virtual Good is not enabled")]
 VirtualGoodDisabled = 3

 ***/
#pragma mark  - MDPHTTPErrorMessageCodeType
typedef NS_ENUM(NSInteger, MDPHTTPErrorMessageCodeType) {
    MDPHTTPErrorMessageCodeTypeUnknown                      = -1,
    MDPHTTPErrorMessageCodeTypeFanIsTooYoung                = 0,
    MDPHTTPErrorMessageCodeTypeFanAgeIsNotDefined           = 1,
    MDPHTTPErrorMessageCodeTypeFanDoesNotHaveEnoughPoints   = 2,
    MDPHTTPErrorMessageCodeTypeVirtualGoodIsNotEnabled      = 3,
};


#pragma mark - Interface
@interface NSError (MDPError)

- (MDPHTTPErrorStatusCode)mdpHTTPErrorStatusCode;
- (NSString *)mdpHTTPErrorMessage;
- (MDPHTTPErrorMessageCodeType)mdpHTTPErrorMessageCode;

@end
