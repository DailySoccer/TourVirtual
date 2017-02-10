//
//  MDPLiveFootBallSeasonPlayerStatModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPLiveFootBallSeasonPlayerStatModel.h"


#pragma mark - Interface
@interface MDPLiveFootBallSeasonPlayerStatModel : _MDPLiveFootBallSeasonPlayerStatModel

+ (NSArray *)liveFootBallSeasonPlayerStatWithIdSeason:idSeason
                                             idPlayer:(NSString *)idPlayer
                                 managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsLiveFootBallSeasonPlayerStatWithIdSeason:idSeason
                                                               dictionary:(NSDictionary *)dictionary
                                                     managedObjectContext:(NSManagedObjectContext *)context;

@end
