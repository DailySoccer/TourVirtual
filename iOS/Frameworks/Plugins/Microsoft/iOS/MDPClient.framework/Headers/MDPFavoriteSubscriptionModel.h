//
//  MDPFavoriteSubscriptionModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPFavoriteSubscriptionModel.h"


#pragma mark - Interface
@interface MDPFavoriteSubscriptionModel : _MDPFavoriteSubscriptionModel

+ (MDPFavoriteSubscriptionModel *)favoriteSubscriptionWithSubscriptionId:(NSString *)subscriptionId managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsFavoriteSubscriptionWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)favoriteSubscriptionFetchedResultsControllerWithManagedObjectContext:(NSManagedObjectContext *)context
                                                                                            delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
