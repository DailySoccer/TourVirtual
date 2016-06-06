//
//  MDPStateModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPStateModel.h"


#pragma mark - Interface
@interface MDPStateModel : _MDPStateModel

+ (instancetype)insertIfNotExistsStateWithDictionary:(NSDictionary *)dictionary
                                managedObjectContext:(NSManagedObjectContext *)context;

@end
