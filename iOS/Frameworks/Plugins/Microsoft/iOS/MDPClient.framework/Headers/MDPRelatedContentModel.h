//
//  MDPRelatedContentModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPRelatedContentModel.h"


#pragma mark - Interface
@interface MDPRelatedContentModel : _MDPRelatedContentModel

+ (instancetype)insertIfNotExistsRelatedContentWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
