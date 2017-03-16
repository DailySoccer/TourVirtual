//
//  MDPHonourModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPHonourModel.h"


#pragma mark - Interface
@interface MDPHonourModel : _MDPHonourModel

+ (instancetype)insertIfNotExistsHonourWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
