//
//  MDPFavoriteContentModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPFavoriteContentModel.h"


#pragma mark - Interface
@interface MDPFavoriteContentModel : _MDPFavoriteContentModel

+ (instancetype)favoriteContentWithId:(NSString *)idContent managedObjectContext:(NSManagedObjectContext *)context;
+ (instancetype)insertIfNotExistsFavoriteContentWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)favoriteNewsFetchedResultsControllerWithFilters:(NSArray *)filters anagedObjectContext:(NSManagedObjectContext *)context delegate:(id <NSFetchedResultsControllerDelegate>)delegate;
+ (NSFetchedResultsController *)favoriteVideosFetchedResultsControllerWithFilters:(NSArray *)filters managedObjectContext:(NSManagedObjectContext *)context delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
