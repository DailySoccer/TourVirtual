//
//  MDPIndexedGroupModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPIndexedGroupModel.h"


#pragma mark - Interface
@interface MDPIndexedGroupModel : _MDPIndexedGroupModel

+ (instancetype)insertIfNotExistsIndexedGroupWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
