//
//  MDPPagedVirtualGoodTypeModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPPagedVirtualGoodTypeModel.h"


#pragma mark - Interface
@interface MDPPagedVirtualGoodTypeModel : _MDPPagedVirtualGoodTypeModel

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)pagedVirtualGoodTypeFetchedResultsControllerWithCt:(NSNumber *)ct
                                                                              type:(NSString *)type
                                                              managedObjectContext:(NSManagedObjectContext *)context
                                                                          delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
