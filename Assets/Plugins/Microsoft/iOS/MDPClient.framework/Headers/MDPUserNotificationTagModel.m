//
//  MDPUserNotificationTagModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "MDPUserNotificationTagModel.h"


#pragma mark - Interface
@interface MDPUserNotificationTagModel ()

@property (nonatomic, strong) NSMutableDictionary *dictionary;

@end


#pragma mark - Implementation
@implementation MDPUserNotificationTagModel

- (instancetype)init
{
    self = [super init];

    if (self) {
    }

    return self;
}

- (void)addUserNotificationTagWithText:(NSString *)text enabled:(BOOL)enabled
{
    if (!text) {
        MDPModelLog(@"The text can not be nil");
    }

    self.dictionary = [[NSMutableDictionary alloc] init];
    self.dictionary[@"Text"] = text;
    self.dictionary[@"Enabled"] = enabled ? @"true" : @"false";
}

- (NSDictionary *)dictionaryFromUserNotificationTag
{
    return  self.dictionary;
}

@end
