//
//  MDPOpenThreadModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPOpenThreadModel.h"


#pragma mark - Interface
@interface MDPOpenThreadModel : _MDPOpenThreadModel

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)openThreadsFetchedResultsControllerWithManagedObjectContext:(NSManagedObjectContext *)context delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
