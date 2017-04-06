//
//  MDPPreferredPlayerModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPPreferredPlayerModel.h"


#pragma mark - SportType
typedef NS_ENUM(NSInteger, MDPPreferredPlayerModelSportType) {
    MDPPreferredPlayerModelSportTypeFootball  = 1,
    MDPPreferredPlayerModelSportTypeBasket    = 2,
};


#pragma mark - Interface
@interface MDPPreferredPlayerModel : _MDPPreferredPlayerModel

+ (NSArray *)preferredPlayerWithSport:(MDPPreferredPlayerModelSportType)sportType managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsPreferredPlayerWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

/*
 Create a dictionary with the followinf data: 
 
 Key: PlayerId Value: parameter playerId;
 Key: PlayerName Value: parameter playerName
 Key: Order Value: parameter order
 Key: Sport Value: parameter sport
 */
- (NSDictionary *)createDictionaryOfPreferredPlayerWith:(NSString *)playerId
                                             playerName:(NSString *)playerName
                                                  order:(NSInteger)order
                                                  sport:(MDPPreferredPlayerModelSportType)sport;

@end
