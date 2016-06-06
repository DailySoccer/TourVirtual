//
//  MDPPointsTransactionModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPPointsTransactionModel.h"


#pragma mark - Interface
@interface MDPPointsTransactionModel : _MDPPointsTransactionModel

+ (instancetype)insertIfNotExistsPointsTransactionWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
