//
//  MDPAppModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPAppModel.h"


#pragma mark - Interface
@interface MDPAppModel : _MDPAppModel

+ (instancetype)appWithAppId:(NSString *)appId deviceId:(NSString *)deviceId managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsAppWithAppId:appId dictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
