//
//  MDPFanMaxScoreModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPFanMaxScoreModel.h"


#pragma mark - Interface
@interface MDPFanMaxScoreModel : _MDPFanMaxScoreModel

+ (instancetype)fanMaxScoreWithIdGame:(NSString *)idGame managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsFanMaxScoreWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
