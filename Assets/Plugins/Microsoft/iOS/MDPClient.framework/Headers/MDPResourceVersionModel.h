//
//  MDPResourceVersionModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPResourceVersionModel.h"


#pragma mark - Interface
@interface MDPResourceVersionModel : _MDPResourceVersionModel

+ (MDPResourceVersionModel *)resourceWithAppId:(NSString *)appId major:(int)major managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsResourceWithAppId:(NSString *)appId dictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
