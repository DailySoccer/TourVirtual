//
//  MDPVirtualGoodTypeModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPVirtualGoodTypeModel.h"


#pragma mark - Interface
@interface MDPVirtualGoodTypeModel : _MDPVirtualGoodTypeModel

+ (instancetype)insertIfNotExistsVirtualGoodTypeWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (MDPVirtualGoodTypeModel *)virtualGoodTypeWithIdType:(NSString *)idType managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)parentVirtualGoodTypeFetchedResultsControllerWithManagedObjectContext:(NSManagedObjectContext *)context
                                                                                             delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)virtualGoodTypeFetchedResultsControllerWithParentIdType:(NSString *)parentIdType
                                                                   managedObjectContext:(NSManagedObjectContext *)context
                                                                               delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
