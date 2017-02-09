//
//  MDPMessageModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPMessageModel.h"


#pragma mark - Interface
@interface MDPMessageModel : _MDPMessageModel

+ (instancetype)messageWithIdThread:(NSString *)idThread idSender:(NSString *)idSender idMessage:(NSString *)idMessage managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)messageWithIdMessage:(NSString *)idMessage managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsMessageWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

+ (NSFetchedResultsController *)messagesFetchedResultsControllerWithThread:(NSString *)idThread managedObjectContext:(NSManagedObjectContext *)context delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
