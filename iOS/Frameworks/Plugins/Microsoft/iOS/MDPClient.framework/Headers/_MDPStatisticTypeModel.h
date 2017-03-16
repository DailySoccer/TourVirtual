//
//  _MDPStatisticTypeModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPStatisticTypeModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPStatisticTypeModelAttributes {
	__unsafe_unretained NSString *idStatisticType;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *recordType;
	__unsafe_unretained NSString *statisticType;
	__unsafe_unretained NSString *value;
} MDPStatisticTypeModelAttributes;

extern const struct MDPStatisticTypeModelRelationships {
	__unsafe_unretained NSString *footballLiveMatchPlayerStatisticsStats;
	__unsafe_unretained NSString *liveFootBallSeasonCompetitionPlayerStatStatistics;
	__unsafe_unretained NSString *liveFootBallSeasonCompetitionStatStatistics;
	__unsafe_unretained NSString *liveFootBallSeasonCompetitionTeamPlayersStatistics;
	__unsafe_unretained NSString *liveFootBallSeasonCompetitionTeamStatStatistics;
	__unsafe_unretained NSString *liveFootBallSeasonPlayerStatStatistics;
	__unsafe_unretained NSString *teamStatisticStatistics;
} MDPStatisticTypeModelRelationships;

@class MDPFootballLiveMatchPlayerStatisticsModel;
@class MDPLiveFootBallSeasonCompetitionPlayerStatModel;
@class MDPLiveFootBallSeasonCompetitionStatModel;
@class MDPLiveFootBallSeasonCompetitionTeamPlayersStatModel;
@class MDPLiveFootBallSeasonCompetitionTeamStatModel;
@class MDPLiveFootBallSeasonPlayerStatModel;
@class MDPTeamStatisticModel;

@interface _MDPStatisticTypeModel : NSManagedObject

@property (nonatomic, strong) NSString* idStatisticType;

//- (BOOL)validateIdStatisticType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* recordType;

//- (BOOL)validateRecordType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* statisticType;

//- (BOOL)validateStatisticType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDecimalNumber* value;

//- (BOOL)validateValue:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPFootballLiveMatchPlayerStatisticsModel *footballLiveMatchPlayerStatisticsStats;

//- (BOOL)validateFootballLiveMatchPlayerStatisticsStats:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPLiveFootBallSeasonCompetitionPlayerStatModel *liveFootBallSeasonCompetitionPlayerStatStatistics;

//- (BOOL)validateLiveFootBallSeasonCompetitionPlayerStatStatistics:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPLiveFootBallSeasonCompetitionStatModel *liveFootBallSeasonCompetitionStatStatistics;

//- (BOOL)validateLiveFootBallSeasonCompetitionStatStatistics:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPLiveFootBallSeasonCompetitionTeamPlayersStatModel *liveFootBallSeasonCompetitionTeamPlayersStatistics;

//- (BOOL)validateLiveFootBallSeasonCompetitionTeamPlayersStatistics:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPLiveFootBallSeasonCompetitionTeamStatModel *liveFootBallSeasonCompetitionTeamStatStatistics;

//- (BOOL)validateLiveFootBallSeasonCompetitionTeamStatStatistics:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPLiveFootBallSeasonPlayerStatModel *liveFootBallSeasonPlayerStatStatistics;

//- (BOOL)validateLiveFootBallSeasonPlayerStatStatistics:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPTeamStatisticModel *teamStatisticStatistics;

//- (BOOL)validateTeamStatisticStatistics:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPStatisticTypeModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveIdStatisticType;
- (void)setPrimitiveIdStatisticType:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveRecordType;
- (void)setPrimitiveRecordType:(NSString*)value;

- (NSString*)primitiveStatisticType;
- (void)setPrimitiveStatisticType:(NSString*)value;

- (NSDecimalNumber*)primitiveValue;
- (void)setPrimitiveValue:(NSDecimalNumber*)value;

- (MDPFootballLiveMatchPlayerStatisticsModel*)primitiveFootballLiveMatchPlayerStatisticsStats;
- (void)setPrimitiveFootballLiveMatchPlayerStatisticsStats:(MDPFootballLiveMatchPlayerStatisticsModel*)value;

- (MDPLiveFootBallSeasonCompetitionPlayerStatModel*)primitiveLiveFootBallSeasonCompetitionPlayerStatStatistics;
- (void)setPrimitiveLiveFootBallSeasonCompetitionPlayerStatStatistics:(MDPLiveFootBallSeasonCompetitionPlayerStatModel*)value;

- (MDPLiveFootBallSeasonCompetitionStatModel*)primitiveLiveFootBallSeasonCompetitionStatStatistics;
- (void)setPrimitiveLiveFootBallSeasonCompetitionStatStatistics:(MDPLiveFootBallSeasonCompetitionStatModel*)value;

- (MDPLiveFootBallSeasonCompetitionTeamPlayersStatModel*)primitiveLiveFootBallSeasonCompetitionTeamPlayersStatistics;
- (void)setPrimitiveLiveFootBallSeasonCompetitionTeamPlayersStatistics:(MDPLiveFootBallSeasonCompetitionTeamPlayersStatModel*)value;

- (MDPLiveFootBallSeasonCompetitionTeamStatModel*)primitiveLiveFootBallSeasonCompetitionTeamStatStatistics;
- (void)setPrimitiveLiveFootBallSeasonCompetitionTeamStatStatistics:(MDPLiveFootBallSeasonCompetitionTeamStatModel*)value;

- (MDPLiveFootBallSeasonPlayerStatModel*)primitiveLiveFootBallSeasonPlayerStatStatistics;
- (void)setPrimitiveLiveFootBallSeasonPlayerStatStatistics:(MDPLiveFootBallSeasonPlayerStatModel*)value;

- (MDPTeamStatisticModel*)primitiveTeamStatisticStatistics;
- (void)setPrimitiveTeamStatisticStatistics:(MDPTeamStatisticModel*)value;

@end
