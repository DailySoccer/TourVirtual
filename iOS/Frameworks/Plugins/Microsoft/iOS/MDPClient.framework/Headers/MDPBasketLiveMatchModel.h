//
//  MDPBasketLiveMatchModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPBasketLiveMatchModel.h"


#pragma mark - Interface
@interface MDPBasketLiveMatchModel : _MDPBasketLiveMatchModel

+ (MDPBasketLiveMatchModel *)basketLiveMatchWithIdSeason:(NSString *)idSeason
                                           idCompetition:(NSString *)idCompetition
                                                 idMatch:(NSString *)idMatch
                                    managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsBasketLiveMatchWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
