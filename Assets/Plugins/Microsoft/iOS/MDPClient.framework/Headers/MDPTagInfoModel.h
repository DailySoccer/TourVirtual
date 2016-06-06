//
//  MDPTagInfoModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPTagInfoModel.h"


#pragma mark - Interface
@interface MDPTagInfoModel : _MDPTagInfoModel

+ (NSArray *)tagsInfoWithManagedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsTagInfoWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
