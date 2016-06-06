//
//  MDPPlayerChangeModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPPlayerChangeModel.h"


#pragma mark - Interface
@interface MDPPlayerChangeModel : _MDPPlayerChangeModel

+ (instancetype)insertIfNotExistsPlayerChangeWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
