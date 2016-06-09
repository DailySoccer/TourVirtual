//
//  MDPFriendModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPFriendModel.h"


#pragma mark - Interface
@interface MDPFriendModel : _MDPFriendModel

+ (NSArray *)friendsWithManagedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsCompetitionWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
