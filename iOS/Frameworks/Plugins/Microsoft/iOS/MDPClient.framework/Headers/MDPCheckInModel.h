//
//  MDPCheckInModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPCheckInModel.h"


#pragma mark - Interface
@interface MDPCheckInModel : _MDPCheckInModel

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)checkInFetchedResultsControllerWithIdUser:(NSString *)idUser managedObjectContext:(NSManagedObjectContext *)context
                                                                 delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
