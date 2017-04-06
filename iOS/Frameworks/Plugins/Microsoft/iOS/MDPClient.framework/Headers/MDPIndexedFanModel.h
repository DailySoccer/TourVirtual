//
//  MDPIndexedFanModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPIndexedFanModel.h"


#pragma mark - Interface
@interface MDPIndexedFanModel : _MDPIndexedFanModel

+ (NSArray *)indexedFansWithManagedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsIndexedFanWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
