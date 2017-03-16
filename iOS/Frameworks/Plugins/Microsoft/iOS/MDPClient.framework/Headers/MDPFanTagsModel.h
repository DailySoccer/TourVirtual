//
//  MDPFanTagsModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPFanTagsModel.h"


#pragma mark - Interface
@interface MDPFanTagsModel : _MDPFanTagsModel

+ (NSArray *)fanTagsWithManagedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsFanTagsWithValue:(NSString *)value managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)fanTagWithValue:(NSString *)value managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)fanMeTagsWithManagedObjectContext:(NSManagedObjectContext *)context delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
