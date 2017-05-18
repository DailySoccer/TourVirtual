//
//  MDPResourceModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPResourceModel.h"


#pragma mark - Interface
@interface MDPResourceModel : _MDPResourceModel


#pragma mark - ResourceContentType
typedef NS_ENUM(NSInteger, MDPResourceModelResourceContentType) {
    MDPResourceModelResourceContentTypeText         = 0,
    MDPResourceModelResourceContentTypeXml          = 1,
    MDPResourceModelResourceContentTypeJson         = 2,
};

+ (MDPResourceModel *)resourceWithAppId:(NSString *)appId major:(int)major minor:(int)minor managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsResourceWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
