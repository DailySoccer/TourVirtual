//
//  MDPUserVideoRatingModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPUserVideoRatingModel.h"


#pragma mark - Interface
@interface MDPUserVideoRatingModel : _MDPUserVideoRatingModel

+ (instancetype)userVideoRatingWithId:(NSString *)videoId managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)userVideoRatingFetchedResultsControllerWithVideoId:(NSString *)videoId managedObjectContext:(NSManagedObjectContext *)context delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
