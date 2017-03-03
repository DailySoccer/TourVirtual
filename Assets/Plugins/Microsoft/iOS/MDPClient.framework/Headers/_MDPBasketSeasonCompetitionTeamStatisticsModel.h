//
//  _MDPBasketSeasonCompetitionTeamStatisticsModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPBasketSeasonCompetitionTeamStatisticsModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPBasketSeasonCompetitionTeamStatisticsModelAttributes {
	__unsafe_unretained NSString *freeShotsAccuracy;
	__unsafe_unretained NSString *idTeam;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *teamName;
	__unsafe_unretained NSString *threePointShotsAccuracy;
	__unsafe_unretained NSString *totalAssists;
	__unsafe_unretained NSString *totalBlocks;
	__unsafe_unretained NSString *totalDefensiveRebouns;
	__unsafe_unretained NSString *totalFreeShots;
	__unsafe_unretained NSString *totalFreeShotsScored;
	__unsafe_unretained NSString *totalOffensiveRebounds;
	__unsafe_unretained NSString *totalPersonalFouls;
	__unsafe_unretained NSString *totalPoints;
	__unsafe_unretained NSString *totalReceivedBlocks;
	__unsafe_unretained NSString *totalRecivedFouls;
	__unsafe_unretained NSString *totalSteals;
	__unsafe_unretained NSString *totalSubstitutions;
	__unsafe_unretained NSString *totalThreePointShots;
	__unsafe_unretained NSString *totalThreePointShotsScored;
	__unsafe_unretained NSString *totalTurnovers;
	__unsafe_unretained NSString *totalTwoPointShots;
	__unsafe_unretained NSString *totalTwoPointShotsScored;
	__unsafe_unretained NSString *twoPointsShotsAccuracy;
} MDPBasketSeasonCompetitionTeamStatisticsModelAttributes;

extern const struct MDPBasketSeasonCompetitionTeamStatisticsModelRelationships {
	__unsafe_unretained NSString *multipleTeamsStatisticsRequest;
	__unsafe_unretained NSString *teamStatisticsRequest;
} MDPBasketSeasonCompetitionTeamStatisticsModelRelationships;

@class MDPBasketSeasonCompetitionTeamStatisticsRequestModel;
@class MDPBasketSeasonCompetitionTeamStatisticsRequestModel;

@interface _MDPBasketSeasonCompetitionTeamStatisticsModel : NSManagedObject

@property (nonatomic, strong) NSDecimalNumber* freeShotsAccuracy;

//- (BOOL)validateFreeShotsAccuracy:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idTeam;

//- (BOOL)validateIdTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* teamName;

//- (BOOL)validateTeamName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDecimalNumber* threePointShotsAccuracy;

//- (BOOL)validateThreePointShotsAccuracy:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* totalAssists;

@property (atomic) int64_t totalAssistsValue;
- (int64_t)totalAssistsValue;
- (void)setTotalAssistsValue:(int64_t)value_;

//- (BOOL)validateTotalAssists:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* totalBlocks;

@property (atomic) int64_t totalBlocksValue;
- (int64_t)totalBlocksValue;
- (void)setTotalBlocksValue:(int64_t)value_;

//- (BOOL)validateTotalBlocks:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* totalDefensiveRebouns;

@property (atomic) int64_t totalDefensiveRebounsValue;
- (int64_t)totalDefensiveRebounsValue;
- (void)setTotalDefensiveRebounsValue:(int64_t)value_;

//- (BOOL)validateTotalDefensiveRebouns:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* totalFreeShots;

@property (atomic) int64_t totalFreeShotsValue;
- (int64_t)totalFreeShotsValue;
- (void)setTotalFreeShotsValue:(int64_t)value_;

//- (BOOL)validateTotalFreeShots:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* totalFreeShotsScored;

@property (atomic) int64_t totalFreeShotsScoredValue;
- (int64_t)totalFreeShotsScoredValue;
- (void)setTotalFreeShotsScoredValue:(int64_t)value_;

//- (BOOL)validateTotalFreeShotsScored:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* totalOffensiveRebounds;

@property (atomic) int64_t totalOffensiveReboundsValue;
- (int64_t)totalOffensiveReboundsValue;
- (void)setTotalOffensiveReboundsValue:(int64_t)value_;

//- (BOOL)validateTotalOffensiveRebounds:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* totalPersonalFouls;

@property (atomic) int64_t totalPersonalFoulsValue;
- (int64_t)totalPersonalFoulsValue;
- (void)setTotalPersonalFoulsValue:(int64_t)value_;

//- (BOOL)validateTotalPersonalFouls:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* totalPoints;

@property (atomic) int64_t totalPointsValue;
- (int64_t)totalPointsValue;
- (void)setTotalPointsValue:(int64_t)value_;

//- (BOOL)validateTotalPoints:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* totalReceivedBlocks;

@property (atomic) int64_t totalReceivedBlocksValue;
- (int64_t)totalReceivedBlocksValue;
- (void)setTotalReceivedBlocksValue:(int64_t)value_;

//- (BOOL)validateTotalReceivedBlocks:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* totalRecivedFouls;

@property (atomic) int64_t totalRecivedFoulsValue;
- (int64_t)totalRecivedFoulsValue;
- (void)setTotalRecivedFoulsValue:(int64_t)value_;

//- (BOOL)validateTotalRecivedFouls:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* totalSteals;

@property (atomic) int64_t totalStealsValue;
- (int64_t)totalStealsValue;
- (void)setTotalStealsValue:(int64_t)value_;

//- (BOOL)validateTotalSteals:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* totalSubstitutions;

@property (atomic) int64_t totalSubstitutionsValue;
- (int64_t)totalSubstitutionsValue;
- (void)setTotalSubstitutionsValue:(int64_t)value_;

//- (BOOL)validateTotalSubstitutions:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* totalThreePointShots;

@property (atomic) int64_t totalThreePointShotsValue;
- (int64_t)totalThreePointShotsValue;
- (void)setTotalThreePointShotsValue:(int64_t)value_;

//- (BOOL)validateTotalThreePointShots:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* totalThreePointShotsScored;

@property (atomic) int64_t totalThreePointShotsScoredValue;
- (int64_t)totalThreePointShotsScoredValue;
- (void)setTotalThreePointShotsScoredValue:(int64_t)value_;

//- (BOOL)validateTotalThreePointShotsScored:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* totalTurnovers;

@property (atomic) int64_t totalTurnoversValue;
- (int64_t)totalTurnoversValue;
- (void)setTotalTurnoversValue:(int64_t)value_;

//- (BOOL)validateTotalTurnovers:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* totalTwoPointShots;

@property (atomic) int64_t totalTwoPointShotsValue;
- (int64_t)totalTwoPointShotsValue;
- (void)setTotalTwoPointShotsValue:(int64_t)value_;

//- (BOOL)validateTotalTwoPointShots:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* totalTwoPointShotsScored;

@property (atomic) int64_t totalTwoPointShotsScoredValue;
- (int64_t)totalTwoPointShotsScoredValue;
- (void)setTotalTwoPointShotsScoredValue:(int64_t)value_;

//- (BOOL)validateTotalTwoPointShotsScored:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDecimalNumber* twoPointsShotsAccuracy;

//- (BOOL)validateTwoPointsShotsAccuracy:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPBasketSeasonCompetitionTeamStatisticsRequestModel *multipleTeamsStatisticsRequest;

//- (BOOL)validateMultipleTeamsStatisticsRequest:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPBasketSeasonCompetitionTeamStatisticsRequestModel *teamStatisticsRequest;

//- (BOOL)validateTeamStatisticsRequest:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPBasketSeasonCompetitionTeamStatisticsModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDecimalNumber*)primitiveFreeShotsAccuracy;
- (void)setPrimitiveFreeShotsAccuracy:(NSDecimalNumber*)value;

- (NSString*)primitiveIdTeam;
- (void)setPrimitiveIdTeam:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveTeamName;
- (void)setPrimitiveTeamName:(NSString*)value;

- (NSDecimalNumber*)primitiveThreePointShotsAccuracy;
- (void)setPrimitiveThreePointShotsAccuracy:(NSDecimalNumber*)value;

- (NSNumber*)primitiveTotalAssists;
- (void)setPrimitiveTotalAssists:(NSNumber*)value;

- (int64_t)primitiveTotalAssistsValue;
- (void)setPrimitiveTotalAssistsValue:(int64_t)value_;

- (NSNumber*)primitiveTotalBlocks;
- (void)setPrimitiveTotalBlocks:(NSNumber*)value;

- (int64_t)primitiveTotalBlocksValue;
- (void)setPrimitiveTotalBlocksValue:(int64_t)value_;

- (NSNumber*)primitiveTotalDefensiveRebouns;
- (void)setPrimitiveTotalDefensiveRebouns:(NSNumber*)value;

- (int64_t)primitiveTotalDefensiveRebounsValue;
- (void)setPrimitiveTotalDefensiveRebounsValue:(int64_t)value_;

- (NSNumber*)primitiveTotalFreeShots;
- (void)setPrimitiveTotalFreeShots:(NSNumber*)value;

- (int64_t)primitiveTotalFreeShotsValue;
- (void)setPrimitiveTotalFreeShotsValue:(int64_t)value_;

- (NSNumber*)primitiveTotalFreeShotsScored;
- (void)setPrimitiveTotalFreeShotsScored:(NSNumber*)value;

- (int64_t)primitiveTotalFreeShotsScoredValue;
- (void)setPrimitiveTotalFreeShotsScoredValue:(int64_t)value_;

- (NSNumber*)primitiveTotalOffensiveRebounds;
- (void)setPrimitiveTotalOffensiveRebounds:(NSNumber*)value;

- (int64_t)primitiveTotalOffensiveReboundsValue;
- (void)setPrimitiveTotalOffensiveReboundsValue:(int64_t)value_;

- (NSNumber*)primitiveTotalPersonalFouls;
- (void)setPrimitiveTotalPersonalFouls:(NSNumber*)value;

- (int64_t)primitiveTotalPersonalFoulsValue;
- (void)setPrimitiveTotalPersonalFoulsValue:(int64_t)value_;

- (NSNumber*)primitiveTotalPoints;
- (void)setPrimitiveTotalPoints:(NSNumber*)value;

- (int64_t)primitiveTotalPointsValue;
- (void)setPrimitiveTotalPointsValue:(int64_t)value_;

- (NSNumber*)primitiveTotalReceivedBlocks;
- (void)setPrimitiveTotalReceivedBlocks:(NSNumber*)value;

- (int64_t)primitiveTotalReceivedBlocksValue;
- (void)setPrimitiveTotalReceivedBlocksValue:(int64_t)value_;

- (NSNumber*)primitiveTotalRecivedFouls;
- (void)setPrimitiveTotalRecivedFouls:(NSNumber*)value;

- (int64_t)primitiveTotalRecivedFoulsValue;
- (void)setPrimitiveTotalRecivedFoulsValue:(int64_t)value_;

- (NSNumber*)primitiveTotalSteals;
- (void)setPrimitiveTotalSteals:(NSNumber*)value;

- (int64_t)primitiveTotalStealsValue;
- (void)setPrimitiveTotalStealsValue:(int64_t)value_;

- (NSNumber*)primitiveTotalSubstitutions;
- (void)setPrimitiveTotalSubstitutions:(NSNumber*)value;

- (int64_t)primitiveTotalSubstitutionsValue;
- (void)setPrimitiveTotalSubstitutionsValue:(int64_t)value_;

- (NSNumber*)primitiveTotalThreePointShots;
- (void)setPrimitiveTotalThreePointShots:(NSNumber*)value;

- (int64_t)primitiveTotalThreePointShotsValue;
- (void)setPrimitiveTotalThreePointShotsValue:(int64_t)value_;

- (NSNumber*)primitiveTotalThreePointShotsScored;
- (void)setPrimitiveTotalThreePointShotsScored:(NSNumber*)value;

- (int64_t)primitiveTotalThreePointShotsScoredValue;
- (void)setPrimitiveTotalThreePointShotsScoredValue:(int64_t)value_;

- (NSNumber*)primitiveTotalTurnovers;
- (void)setPrimitiveTotalTurnovers:(NSNumber*)value;

- (int64_t)primitiveTotalTurnoversValue;
- (void)setPrimitiveTotalTurnoversValue:(int64_t)value_;

- (NSNumber*)primitiveTotalTwoPointShots;
- (void)setPrimitiveTotalTwoPointShots:(NSNumber*)value;

- (int64_t)primitiveTotalTwoPointShotsValue;
- (void)setPrimitiveTotalTwoPointShotsValue:(int64_t)value_;

- (NSNumber*)primitiveTotalTwoPointShotsScored;
- (void)setPrimitiveTotalTwoPointShotsScored:(NSNumber*)value;

- (int64_t)primitiveTotalTwoPointShotsScoredValue;
- (void)setPrimitiveTotalTwoPointShotsScoredValue:(int64_t)value_;

- (NSDecimalNumber*)primitiveTwoPointsShotsAccuracy;
- (void)setPrimitiveTwoPointsShotsAccuracy:(NSDecimalNumber*)value;

- (MDPBasketSeasonCompetitionTeamStatisticsRequestModel*)primitiveMultipleTeamsStatisticsRequest;
- (void)setPrimitiveMultipleTeamsStatisticsRequest:(MDPBasketSeasonCompetitionTeamStatisticsRequestModel*)value;

- (MDPBasketSeasonCompetitionTeamStatisticsRequestModel*)primitiveTeamStatisticsRequest;
- (void)setPrimitiveTeamStatisticsRequest:(MDPBasketSeasonCompetitionTeamStatisticsRequestModel*)value;

@end
