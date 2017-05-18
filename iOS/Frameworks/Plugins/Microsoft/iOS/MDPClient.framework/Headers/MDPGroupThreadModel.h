//
//  MDPGroupThreadModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPGroupThreadModel.h"


#pragma mark - Interface
@interface MDPGroupThreadModel : _MDPGroupThreadModel

+ (MDPGroupModel *)groupThreadWithIdThread:(NSString *)idThread
                      managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsGroupThreadWithDictionary:(NSDictionary *)dictionary
                                      managedObjectContext:(NSManagedObjectContext *)context;

@end
