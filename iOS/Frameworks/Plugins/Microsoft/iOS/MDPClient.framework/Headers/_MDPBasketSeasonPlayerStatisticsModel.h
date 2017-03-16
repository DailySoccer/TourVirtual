//
//  _MDPBasketSeasonPlayerStatisticsModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPBasketSeasonPlayerStatisticsModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPBasketSeasonPlayerStatisticsModelAttributes {
	__unsafe_unretained NSString *evaluation;
	__unsafe_unretained NSString *freeShotsAccuracy;
	__unsafe_unretained NSString *idPlayer;
	__unsafe_unretained NSString *idSeason;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *playerName;
	__unsafe_unretained NSString *seasonName;
	__unsafe_unretained NSString *threePointShotsAccuracy;
	__unsafe_unretained NSString *timesAsStarter;
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
	__unsafe_unretained NSString *totalThreePointShots;
	__unsafe_unretained NSString *totalThreePointShotsScored;
	__unsafe_unretained NSString *totalThreePoints;
	__unsafe_unretained NSString *totalTurnovers;
	__unsafe_unretained NSString *totalTwoPointShots;
	__unsafe_unretained NSString *totalTwoPointShotsScored;
	__unsafe_unretained NSString *totalTwoPoints;
	__unsafe_unretained NSString *twoPointsShotsAccuracy;
} MDPBasketSeasonPlayerStatisticsModelAttributes;

@interface _MDPBasketSeasonPlayerStatisticsModel : NSManagedObject

@property (nonatomic, strong) NSNumber* evaluation;

@property (atomic) int64_t evaluationValue;
- (int64_t)evaluationValue;
- (void)setEvaluationValue:(int64_t)value_;

//- (BOOL)validateEvaluation:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDecimalNumber* freeShotsAccuracy;

//- (BOOL)validateFreeShotsAccuracy:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idPlayer;

//- (BOOL)validateIdPlayer:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSeason;

//- (BOOL)validateIdSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* playerName;

//- (BOOL)validatePlayerName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* seasonName;

//- (BOOL)validateSeasonName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDecimalNumber* threePointShotsAccuracy;

//- (BOOL)validateThreePointShotsAccuracy:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* timesAsStarter;

@property (atomic) int64_t timesAsStarterValue;
- (int64_t)timesAsStarterValue;
- (void)setTimesAsStarterValue:(int64_t)value_;

//- (BOOL)validateTimesAsStarter:(id*)value_ error:(NSError**)error_;

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

@property (nonatomic, strong) NSNumber* totalThreePoints;

@property (atomic) int64_t totalThreePointsValue;
- (int64_t)totalThreePointsValue;
- (void)setTotalThreePointsValue:(int64_t)value_;

//- (BOOL)validateTotalThreePoints:(id*)value_ error:(NSError**)error_;

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

@property (nonatomic, strong) NSNumber* totalTwoPoints;

@property (atomic) int64_t totalTwoPointsValue;
- (int64_t)totalTwoPointsValue;
- (void)setTotalTwoPointsValue:(int64_t)value_;

//- (BOOL)validateTotalTwoPoints:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDecimalNumber* twoPointsShotsAccuracy;

//- (BOOL)validateTwoPointsShotsAccuracy:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPBasketSeasonPlayerStatisticsModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveEvaluation;
- (void)setPrimitiveEvaluation:(NSNumber*)value;

- (int64_t)primitiveEvaluationValue;
- (void)setPrimitiveEvaluationValue:(int64_t)value_;

- (NSDecimalNumber*)primitiveFreeShotsAccuracy;
- (void)setPrimitiveFreeShotsAccuracy:(NSDecimalNumber*)value;

- (NSString*)primitiveIdPlayer;
- (void)setPrimitiveIdPlayer:(NSString*)value;

- (NSString*)primitiveIdSeason;
- (void)setPrimitiveIdSeason:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitivePlayerName;
- (void)setPrimitivePlayerName:(NSString*)value;

- (NSString*)primitiveSeasonName;
- (void)setPrimitiveSeasonName:(NSString*)value;

- (NSDecimalNumber*)primitiveThreePointShotsAccuracy;
- (void)setPrimitiveThreePointShotsAccuracy:(NSDecimalNumber*)value;

- (NSNumber*)primitiveTimesAsStarter;
- (void)setPrimitiveTimesAsStarter:(NSNumber*)value;

- (int64_t)primitiveTimesAsStarterValue;
- (void)setPrimitiveTimesAsStarterValue:(int64_t)value_;

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

- (NSNumber*)primitiveTotalThreePointShots;
- (void)setPrimitiveTotalThreePointShots:(NSNumber*)value;

- (int64_t)primitiveTotalThreePointShotsValue;
- (void)setPrimitiveTotalThreePointShotsValue:(int64_t)value_;

- (NSNumber*)primitiveTotalThreePointShotsScored;
- (void)setPrimitiveTotalThreePointShotsScored:(NSNumber*)value;

- (int64_t)primitiveTotalThreePointShotsScoredValue;
- (void)setPrimitiveTotalThreePointShotsScoredValue:(int64_t)value_;

- (NSNumber*)primitiveTotalThreePoints;
- (void)setPrimitiveTotalThreePoints:(NSNumber*)value;

- (int64_t)primitiveTotalThreePointsValue;
- (void)setPrimitiveTotalThreePointsValue:(int64_t)value_;

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

- (NSNumber*)primitiveTotalTwoPoints;
- (void)setPrimitiveTotalTwoPoints:(NSNumber*)value;

- (int64_t)primitiveTotalTwoPointsValue;
- (void)setPrimitiveTotalTwoPointsValue:(int64_t)value_;

- (NSDecimalNumber*)primitiveTwoPointsShotsAccuracy;
- (void)setPrimitiveTwoPointsShotsAccuracy:(NSDecimalNumber*)value;

@end
