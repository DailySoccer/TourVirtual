//
//  MDPCheckInTypeModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPCheckInTypeModel.h"


#pragma mark - Interface
@interface MDPCheckInTypeModel : _MDPCheckInTypeModel

+ (MDPCheckInTypeModel *)checkInTypeWithIdCheckInType:(NSString *)idCheckInType managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsCheckInTypeWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)checkInTypeFetchedResultsControllerWithManagedObjectContext:(NSManagedObjectContext *)context
                                                                                   delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
