//
//  _MDPLiveFootBallSeasonCompetitionPlayerStatModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPLiveFootBallSeasonCompetitionPlayerStatModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPLiveFootBallSeasonCompetitionPlayerStatModelAttributes {
	__unsafe_unretained NSString *idCompetition;
	__unsafe_unretained NSString *idPlayer;
	__unsafe_unretained NSString *idSeason;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *matchDay;
	__unsafe_unretained NSString *playerName;
} MDPLiveFootBallSeasonCompetitionPlayerStatModelAttributes;

extern const struct MDPLiveFootBallSeasonCompetitionPlayerStatModelRelationships {
	__unsafe_unretained NSString *statistics;
} MDPLiveFootBallSeasonCompetitionPlayerStatModelRelationships;

@class MDPStatisticTypeModel;

@interface _MDPLiveFootBallSeasonCompetitionPlayerStatModel : NSManagedObject

@property (nonatomic, strong) NSString* idCompetition;

//- (BOOL)validateIdCompetition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idPlayer;

//- (BOOL)validateIdPlayer:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSeason;

//- (BOOL)validateIdSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* matchDay;

//- (BOOL)validateMatchDay:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* playerName;

//- (BOOL)validatePlayerName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *statistics;

- (NSMutableSet*)statisticsSet;

@end

@interface _MDPLiveFootBallSeasonCompetitionPlayerStatModel (StatisticsCoreDataGeneratedAccessors)
- (void)addStatistics:(NSSet*)value_;
- (void)removeStatistics:(NSSet*)value_;
- (void)addStatisticsObject:(MDPStatisticTypeModel*)value_;
- (void)removeStatisticsObject:(MDPStatisticTypeModel*)value_;
@end

@interface _MDPLiveFootBallSeasonCompetitionPlayerStatModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveIdCompetition;
- (void)setPrimitiveIdCompetition:(NSString*)value;

- (NSString*)primitiveIdPlayer;
- (void)setPrimitiveIdPlayer:(NSString*)value;

- (NSString*)primitiveIdSeason;
- (void)setPrimitiveIdSeason:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveMatchDay;
- (void)setPrimitiveMatchDay:(NSString*)value;

- (NSString*)primitivePlayerName;
- (void)setPrimitivePlayerName:(NSString*)value;

- (NSMutableSet*)primitiveStatistics;
- (void)setPrimitiveStatistics:(NSMutableSet*)value;

@end
