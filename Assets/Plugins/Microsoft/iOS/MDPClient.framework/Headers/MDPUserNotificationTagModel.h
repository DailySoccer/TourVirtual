//
//  MDPUserNotificationTagModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//
@import Foundation;


#pragma mark - Interface
@interface MDPUserNotificationTagModel : NSObject

- (void)addUserNotificationTagWithText:(NSString *)text enabled:(BOOL)enabled;
- (NSDictionary *)dictionaryFromUserNotificationTag;

@end
