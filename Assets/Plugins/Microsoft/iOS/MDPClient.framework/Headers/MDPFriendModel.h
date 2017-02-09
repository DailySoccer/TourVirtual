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

+ (MDPFriendModel *)friendsWithIdUser:(NSString *)idUser idUserFriend:(NSString *)idUserFriend managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsFriendWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)friendsFetchedResultsControllerWithIdUser:(NSString *)idUser managedObjectContext:(NSManagedObjectContext *)context delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
