//
//  MDPScoreRankingModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPScoreRankingModel.h"


#pragma mark - Interface
@interface MDPScoreRankingModel : _MDPScoreRankingModel

+ (NSArray *)scoreRankingWithIdGame:(NSString *)idGame managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
