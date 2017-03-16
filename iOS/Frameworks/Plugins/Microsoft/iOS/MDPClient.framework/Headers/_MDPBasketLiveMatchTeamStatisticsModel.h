//
//  _MDPBasketLiveMatchTeamStatisticsModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPBasketLiveMatchTeamStatisticsModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPBasketLiveMatchTeamStatisticsModelAttributes {
	__unsafe_unretained NSString *assists;
	__unsafe_unretained NSString *blocks;
	__unsafe_unretained NSString *competitionName;
	__unsafe_unretained NSString *defensiveRebouns;
	__unsafe_unretained NSString *freeShots;
	__unsafe_unretained NSString *freeShotsScored;
	__unsafe_unretained NSString *idCompetition;
	__unsafe_unretained NSString *idMatch;
	__unsafe_unretained NSString *idSeason;
	__unsafe_unretained NSString *idTeam;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *offensiveRebounds;
	__unsafe_unretained NSString *personalFouls;
	__unsafe_unretained NSString *points;
	__unsafe_unretained NSString *receivedBlocks;
	__unsafe_unretained NSString *recivedFouls;
	__unsafe_unretained NSString *seasonName;
	__unsafe_unretained NSString *shortsColor;
	__unsafe_unretained NSString *steals;
	__unsafe_unretained NSString *stripColor;
	__unsafe_unretained NSString *substitutions;
	__unsafe_unretained NSString *tShirtColor;
	__unsafe_unretained NSString *teamName;
	__unsafe_unretained NSString *threePointShots;
	__unsafe_unretained NSString *threePointShotsScored;
	__unsafe_unretained NSString *timeouts;
	__unsafe_unretained NSString *turnovers;
	__unsafe_unretained NSString *twoPointShots;
	__unsafe_unretained NSString *twoPointShotsScored;
} MDPBasketLiveMatchTeamStatisticsModelAttributes;

@interface _MDPBasketLiveMatchTeamStatisticsModel : NSManagedObject

@property (nonatomic, strong) NSNumber* assists;

@property (atomic) int64_t assistsValue;
- (int64_t)assistsValue;
- (void)setAssistsValue:(int64_t)value_;

//- (BOOL)validateAssists:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* blocks;

@property (atomic) int64_t blocksValue;
- (int64_t)blocksValue;
- (void)setBlocksValue:(int64_t)value_;

//- (BOOL)validateBlocks:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* competitionName;

//- (BOOL)validateCompetitionName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* defensiveRebouns;

@property (atomic) int64_t defensiveRebounsValue;
- (int64_t)defensiveRebounsValue;
- (void)setDefensiveRebounsValue:(int64_t)value_;

//- (BOOL)validateDefensiveRebouns:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* freeShots;

@property (atomic) int64_t freeShotsValue;
- (int64_t)freeShotsValue;
- (void)setFreeShotsValue:(int64_t)value_;

//- (BOOL)validateFreeShots:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* freeShotsScored;

@property (atomic) int64_t freeShotsScoredValue;
- (int64_t)freeShotsScoredValue;
- (void)setFreeShotsScoredValue:(int64_t)value_;

//- (BOOL)validateFreeShotsScored:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idCompetition;

//- (BOOL)validateIdCompetition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idMatch;

//- (BOOL)validateIdMatch:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSeason;

//- (BOOL)validateIdSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idTeam;

//- (BOOL)validateIdTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* offensiveRebounds;

@property (atomic) int64_t offensiveReboundsValue;
- (int64_t)offensiveReboundsValue;
- (void)setOffensiveReboundsValue:(int64_t)value_;

//- (BOOL)validateOffensiveRebounds:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* personalFouls;

@property (atomic) int64_t personalFoulsValue;
- (int64_t)personalFoulsValue;
- (void)setPersonalFoulsValue:(int64_t)value_;

//- (BOOL)validatePersonalFouls:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* points;

@property (atomic) int64_t pointsValue;
- (int64_t)pointsValue;
- (void)setPointsValue:(int64_t)value_;

//- (BOOL)validatePoints:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* receivedBlocks;

@property (atomic) int64_t receivedBlocksValue;
- (int64_t)receivedBlocksValue;
- (void)setReceivedBlocksValue:(int64_t)value_;

//- (BOOL)validateReceivedBlocks:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* recivedFouls;

@property (atomic) int64_t recivedFoulsValue;
- (int64_t)recivedFoulsValue;
- (void)setRecivedFoulsValue:(int64_t)value_;

//- (BOOL)validateRecivedFouls:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* seasonName;

//- (BOOL)validateSeasonName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* shortsColor;

//- (BOOL)validateShortsColor:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* steals;

@property (atomic) int64_t stealsValue;
- (int64_t)stealsValue;
- (void)setStealsValue:(int64_t)value_;

//- (BOOL)validateSteals:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* stripColor;

//- (BOOL)validateStripColor:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* substitutions;

@property (atomic) int64_t substitutionsValue;
- (int64_t)substitutionsValue;
- (void)setSubstitutionsValue:(int64_t)value_;

//- (BOOL)validateSubstitutions:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* tShirtColor;

//- (BOOL)validateTShirtColor:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* teamName;

//- (BOOL)validateTeamName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* threePointShots;

@property (atomic) int64_t threePointShotsValue;
- (int64_t)threePointShotsValue;
- (void)setThreePointShotsValue:(int64_t)value_;

//- (BOOL)validateThreePointShots:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* threePointShotsScored;

@property (atomic) int64_t threePointShotsScoredValue;
- (int64_t)threePointShotsScoredValue;
- (void)setThreePointShotsScoredValue:(int64_t)value_;

//- (BOOL)validateThreePointShotsScored:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* timeouts;

@property (atomic) int64_t timeoutsValue;
- (int64_t)timeoutsValue;
- (void)setTimeoutsValue:(int64_t)value_;

//- (BOOL)validateTimeouts:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* turnovers;

@property (atomic) int64_t turnoversValue;
- (int64_t)turnoversValue;
- (void)setTurnoversValue:(int64_t)value_;

//- (BOOL)validateTurnovers:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* twoPointShots;

@property (atomic) int64_t twoPointShotsValue;
- (int64_t)twoPointShotsValue;
- (void)setTwoPointShotsValue:(int64_t)value_;

//- (BOOL)validateTwoPointShots:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* twoPointShotsScored;

@property (atomic) int64_t twoPointShotsScoredValue;
- (int64_t)twoPointShotsScoredValue;
- (void)setTwoPointShotsScoredValue:(int64_t)value_;

//- (BOOL)validateTwoPointShotsScored:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPBasketLiveMatchTeamStatisticsModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveAssists;
- (void)setPrimitiveAssists:(NSNumber*)value;

- (int64_t)primitiveAssistsValue;
- (void)setPrimitiveAssistsValue:(int64_t)value_;

- (NSNumber*)primitiveBlocks;
- (void)setPrimitiveBlocks:(NSNumber*)value;

- (int64_t)primitiveBlocksValue;
- (void)setPrimitiveBlocksValue:(int64_t)value_;

- (NSString*)primitiveCompetitionName;
- (void)setPrimitiveCompetitionName:(NSString*)value;

- (NSNumber*)primitiveDefensiveRebouns;
- (void)setPrimitiveDefensiveRebouns:(NSNumber*)value;

- (int64_t)primitiveDefensiveRebounsValue;
- (void)setPrimitiveDefensiveRebounsValue:(int64_t)value_;

- (NSNumber*)primitiveFreeShots;
- (void)setPrimitiveFreeShots:(NSNumber*)value;

- (int64_t)primitiveFreeShotsValue;
- (void)setPrimitiveFreeShotsValue:(int64_t)value_;

- (NSNumber*)primitiveFreeShotsScored;
- (void)setPrimitiveFreeShotsScored:(NSNumber*)value;

- (int64_t)primitiveFreeShotsScoredValue;
- (void)setPrimitiveFreeShotsScoredValue:(int64_t)value_;

- (NSString*)primitiveIdCompetition;
- (void)setPrimitiveIdCompetition:(NSString*)value;

- (NSString*)primitiveIdMatch;
- (void)setPrimitiveIdMatch:(NSString*)value;

- (NSString*)primitiveIdSeason;
- (void)setPrimitiveIdSeason:(NSString*)value;

- (NSString*)primitiveIdTeam;
- (void)setPrimitiveIdTeam:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveOffensiveRebounds;
- (void)setPrimitiveOffensiveRebounds:(NSNumber*)value;

- (int64_t)primitiveOffensiveReboundsValue;
- (void)setPrimitiveOffensiveReboundsValue:(int64_t)value_;

- (NSNumber*)primitivePersonalFouls;
- (void)setPrimitivePersonalFouls:(NSNumber*)value;

- (int64_t)primitivePersonalFoulsValue;
- (void)setPrimitivePersonalFoulsValue:(int64_t)value_;

- (NSNumber*)primitivePoints;
- (void)setPrimitivePoints:(NSNumber*)value;

- (int64_t)primitivePointsValue;
- (void)setPrimitivePointsValue:(int64_t)value_;

- (NSNumber*)primitiveReceivedBlocks;
- (void)setPrimitiveReceivedBlocks:(NSNumber*)value;

- (int64_t)primitiveReceivedBlocksValue;
- (void)setPrimitiveReceivedBlocksValue:(int64_t)value_;

- (NSNumber*)primitiveRecivedFouls;
- (void)setPrimitiveRecivedFouls:(NSNumber*)value;

- (int64_t)primitiveRecivedFoulsValue;
- (void)setPrimitiveRecivedFoulsValue:(int64_t)value_;

- (NSString*)primitiveSeasonName;
- (void)setPrimitiveSeasonName:(NSString*)value;

- (NSString*)primitiveShortsColor;
- (void)setPrimitiveShortsColor:(NSString*)value;

- (NSNumber*)primitiveSteals;
- (void)setPrimitiveSteals:(NSNumber*)value;

- (int64_t)primitiveStealsValue;
- (void)setPrimitiveStealsValue:(int64_t)value_;

- (NSString*)primitiveStripColor;
- (void)setPrimitiveStripColor:(NSString*)value;

- (NSNumber*)primitiveSubstitutions;
- (void)setPrimitiveSubstitutions:(NSNumber*)value;

- (int64_t)primitiveSubstitutionsValue;
- (void)setPrimitiveSubstitutionsValue:(int64_t)value_;

- (NSString*)primitiveTShirtColor;
- (void)setPrimitiveTShirtColor:(NSString*)value;

- (NSString*)primitiveTeamName;
- (void)setPrimitiveTeamName:(NSString*)value;

- (NSNumber*)primitiveThreePointShots;
- (void)setPrimitiveThreePointShots:(NSNumber*)value;

- (int64_t)primitiveThreePointShotsValue;
- (void)setPrimitiveThreePointShotsValue:(int64_t)value_;

- (NSNumber*)primitiveThreePointShotsScored;
- (void)setPrimitiveThreePointShotsScored:(NSNumber*)value;

- (int64_t)primitiveThreePointShotsScoredValue;
- (void)setPrimitiveThreePointShotsScoredValue:(int64_t)value_;

- (NSNumber*)primitiveTimeouts;
- (void)setPrimitiveTimeouts:(NSNumber*)value;

- (int64_t)primitiveTimeoutsValue;
- (void)setPrimitiveTimeoutsValue:(int64_t)value_;

- (NSNumber*)primitiveTurnovers;
- (void)setPrimitiveTurnovers:(NSNumber*)value;

- (int64_t)primitiveTurnoversValue;
- (void)setPrimitiveTurnoversValue:(int64_t)value_;

- (NSNumber*)primitiveTwoPointShots;
- (void)setPrimitiveTwoPointShots:(NSNumber*)value;

- (int64_t)primitiveTwoPointShotsValue;
- (void)setPrimitiveTwoPointShotsValue:(int64_t)value_;

- (NSNumber*)primitiveTwoPointShotsScored;
- (void)setPrimitiveTwoPointShotsScored:(NSNumber*)value;

- (int64_t)primitiveTwoPointShotsScoredValue;
- (void)setPrimitiveTwoPointShotsScoredValue:(int64_t)value_;

@end
