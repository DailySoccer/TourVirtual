//
//  _MDPStandingModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPStandingModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPStandingModelAttributes {
	__unsafe_unretained NSString *against;
	__unsafe_unretained NSString *awayAgainst;
	__unsafe_unretained NSString *awayDrawn;
	__unsafe_unretained NSString *awayFor;
	__unsafe_unretained NSString *awayLost;
	__unsafe_unretained NSString *awayPlayed;
	__unsafe_unretained NSString *awayPoints;
	__unsafe_unretained NSString *awayPosition;
	__unsafe_unretained NSString *awayWon;
	__unsafe_unretained NSString *competitionName;
	__unsafe_unretained NSString *drawn;
	__unsafe_unretained NSString *ffor;
	__unsafe_unretained NSString *groupName;
	__unsafe_unretained NSString *homeAgainst;
	__unsafe_unretained NSString *homeDrawn;
	__unsafe_unretained NSString *homeFor;
	__unsafe_unretained NSString *homeLost;
	__unsafe_unretained NSString *homePlayed;
	__unsafe_unretained NSString *homePoints;
	__unsafe_unretained NSString *homePosition;
	__unsafe_unretained NSString *homeWon;
	__unsafe_unretained NSString *idCompetition;
	__unsafe_unretained NSString *idGroup;
	__unsafe_unretained NSString *idSeason;
	__unsafe_unretained NSString *idTeam;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *lost;
	__unsafe_unretained NSString *matchDay;
	__unsafe_unretained NSString *played;
	__unsafe_unretained NSString *points;
	__unsafe_unretained NSString *position;
	__unsafe_unretained NSString *qualificationType;
	__unsafe_unretained NSString *seasonName;
	__unsafe_unretained NSString *startDayPosition;
	__unsafe_unretained NSString *teamBadgeThumbnailUrl;
	__unsafe_unretained NSString *teamBadgeUrl;
	__unsafe_unretained NSString *teamName;
	__unsafe_unretained NSString *won;
} MDPStandingModelAttributes;

@interface _MDPStandingModel : NSManagedObject

@property (nonatomic, strong) NSNumber* against;

@property (atomic) int64_t againstValue;
- (int64_t)againstValue;
- (void)setAgainstValue:(int64_t)value_;

//- (BOOL)validateAgainst:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* awayAgainst;

@property (atomic) int64_t awayAgainstValue;
- (int64_t)awayAgainstValue;
- (void)setAwayAgainstValue:(int64_t)value_;

//- (BOOL)validateAwayAgainst:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* awayDrawn;

@property (atomic) int64_t awayDrawnValue;
- (int64_t)awayDrawnValue;
- (void)setAwayDrawnValue:(int64_t)value_;

//- (BOOL)validateAwayDrawn:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* awayFor;

@property (atomic) int64_t awayForValue;
- (int64_t)awayForValue;
- (void)setAwayForValue:(int64_t)value_;

//- (BOOL)validateAwayFor:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* awayLost;

@property (atomic) int64_t awayLostValue;
- (int64_t)awayLostValue;
- (void)setAwayLostValue:(int64_t)value_;

//- (BOOL)validateAwayLost:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* awayPlayed;

@property (atomic) int64_t awayPlayedValue;
- (int64_t)awayPlayedValue;
- (void)setAwayPlayedValue:(int64_t)value_;

//- (BOOL)validateAwayPlayed:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* awayPoints;

@property (atomic) int64_t awayPointsValue;
- (int64_t)awayPointsValue;
- (void)setAwayPointsValue:(int64_t)value_;

//- (BOOL)validateAwayPoints:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* awayPosition;

@property (atomic) int64_t awayPositionValue;
- (int64_t)awayPositionValue;
- (void)setAwayPositionValue:(int64_t)value_;

//- (BOOL)validateAwayPosition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* awayWon;

@property (atomic) int64_t awayWonValue;
- (int64_t)awayWonValue;
- (void)setAwayWonValue:(int64_t)value_;

//- (BOOL)validateAwayWon:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* competitionName;

//- (BOOL)validateCompetitionName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* drawn;

@property (atomic) int64_t drawnValue;
- (int64_t)drawnValue;
- (void)setDrawnValue:(int64_t)value_;

//- (BOOL)validateDrawn:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* ffor;

@property (atomic) int64_t fforValue;
- (int64_t)fforValue;
- (void)setFforValue:(int64_t)value_;

//- (BOOL)validateFfor:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* groupName;

//- (BOOL)validateGroupName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* homeAgainst;

@property (atomic) int64_t homeAgainstValue;
- (int64_t)homeAgainstValue;
- (void)setHomeAgainstValue:(int64_t)value_;

//- (BOOL)validateHomeAgainst:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* homeDrawn;

@property (atomic) int64_t homeDrawnValue;
- (int64_t)homeDrawnValue;
- (void)setHomeDrawnValue:(int64_t)value_;

//- (BOOL)validateHomeDrawn:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* homeFor;

@property (atomic) int64_t homeForValue;
- (int64_t)homeForValue;
- (void)setHomeForValue:(int64_t)value_;

//- (BOOL)validateHomeFor:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* homeLost;

@property (atomic) int64_t homeLostValue;
- (int64_t)homeLostValue;
- (void)setHomeLostValue:(int64_t)value_;

//- (BOOL)validateHomeLost:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* homePlayed;

@property (atomic) int64_t homePlayedValue;
- (int64_t)homePlayedValue;
- (void)setHomePlayedValue:(int64_t)value_;

//- (BOOL)validateHomePlayed:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* homePoints;

@property (atomic) int64_t homePointsValue;
- (int64_t)homePointsValue;
- (void)setHomePointsValue:(int64_t)value_;

//- (BOOL)validateHomePoints:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* homePosition;

@property (atomic) int64_t homePositionValue;
- (int64_t)homePositionValue;
- (void)setHomePositionValue:(int64_t)value_;

//- (BOOL)validateHomePosition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* homeWon;

@property (atomic) int64_t homeWonValue;
- (int64_t)homeWonValue;
- (void)setHomeWonValue:(int64_t)value_;

//- (BOOL)validateHomeWon:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idCompetition;

//- (BOOL)validateIdCompetition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idGroup;

//- (BOOL)validateIdGroup:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSeason;

//- (BOOL)validateIdSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idTeam;

//- (BOOL)validateIdTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* lost;

@property (atomic) int64_t lostValue;
- (int64_t)lostValue;
- (void)setLostValue:(int64_t)value_;

//- (BOOL)validateLost:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* matchDay;

//- (BOOL)validateMatchDay:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* played;

@property (atomic) int64_t playedValue;
- (int64_t)playedValue;
- (void)setPlayedValue:(int64_t)value_;

//- (BOOL)validatePlayed:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* points;

@property (atomic) int64_t pointsValue;
- (int64_t)pointsValue;
- (void)setPointsValue:(int64_t)value_;

//- (BOOL)validatePoints:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* position;

@property (atomic) int64_t positionValue;
- (int64_t)positionValue;
- (void)setPositionValue:(int64_t)value_;

//- (BOOL)validatePosition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* qualificationType;

@property (atomic) uint16_t qualificationTypeValue;
- (uint16_t)qualificationTypeValue;
- (void)setQualificationTypeValue:(uint16_t)value_;

//- (BOOL)validateQualificationType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* seasonName;

//- (BOOL)validateSeasonName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* startDayPosition;

@property (atomic) int64_t startDayPositionValue;
- (int64_t)startDayPositionValue;
- (void)setStartDayPositionValue:(int64_t)value_;

//- (BOOL)validateStartDayPosition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* teamBadgeThumbnailUrl;

//- (BOOL)validateTeamBadgeThumbnailUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* teamBadgeUrl;

//- (BOOL)validateTeamBadgeUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* teamName;

//- (BOOL)validateTeamName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* won;

@property (atomic) int64_t wonValue;
- (int64_t)wonValue;
- (void)setWonValue:(int64_t)value_;

//- (BOOL)validateWon:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPStandingModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveAgainst;
- (void)setPrimitiveAgainst:(NSNumber*)value;

- (int64_t)primitiveAgainstValue;
- (void)setPrimitiveAgainstValue:(int64_t)value_;

- (NSNumber*)primitiveAwayAgainst;
- (void)setPrimitiveAwayAgainst:(NSNumber*)value;

- (int64_t)primitiveAwayAgainstValue;
- (void)setPrimitiveAwayAgainstValue:(int64_t)value_;

- (NSNumber*)primitiveAwayDrawn;
- (void)setPrimitiveAwayDrawn:(NSNumber*)value;

- (int64_t)primitiveAwayDrawnValue;
- (void)setPrimitiveAwayDrawnValue:(int64_t)value_;

- (NSNumber*)primitiveAwayFor;
- (void)setPrimitiveAwayFor:(NSNumber*)value;

- (int64_t)primitiveAwayForValue;
- (void)setPrimitiveAwayForValue:(int64_t)value_;

- (NSNumber*)primitiveAwayLost;
- (void)setPrimitiveAwayLost:(NSNumber*)value;

- (int64_t)primitiveAwayLostValue;
- (void)setPrimitiveAwayLostValue:(int64_t)value_;

- (NSNumber*)primitiveAwayPlayed;
- (void)setPrimitiveAwayPlayed:(NSNumber*)value;

- (int64_t)primitiveAwayPlayedValue;
- (void)setPrimitiveAwayPlayedValue:(int64_t)value_;

- (NSNumber*)primitiveAwayPoints;
- (void)setPrimitiveAwayPoints:(NSNumber*)value;

- (int64_t)primitiveAwayPointsValue;
- (void)setPrimitiveAwayPointsValue:(int64_t)value_;

- (NSNumber*)primitiveAwayPosition;
- (void)setPrimitiveAwayPosition:(NSNumber*)value;

- (int64_t)primitiveAwayPositionValue;
- (void)setPrimitiveAwayPositionValue:(int64_t)value_;

- (NSNumber*)primitiveAwayWon;
- (void)setPrimitiveAwayWon:(NSNumber*)value;

- (int64_t)primitiveAwayWonValue;
- (void)setPrimitiveAwayWonValue:(int64_t)value_;

- (NSString*)primitiveCompetitionName;
- (void)setPrimitiveCompetitionName:(NSString*)value;

- (NSNumber*)primitiveDrawn;
- (void)setPrimitiveDrawn:(NSNumber*)value;

- (int64_t)primitiveDrawnValue;
- (void)setPrimitiveDrawnValue:(int64_t)value_;

- (NSNumber*)primitiveFfor;
- (void)setPrimitiveFfor:(NSNumber*)value;

- (int64_t)primitiveFforValue;
- (void)setPrimitiveFforValue:(int64_t)value_;

- (NSString*)primitiveGroupName;
- (void)setPrimitiveGroupName:(NSString*)value;

- (NSNumber*)primitiveHomeAgainst;
- (void)setPrimitiveHomeAgainst:(NSNumber*)value;

- (int64_t)primitiveHomeAgainstValue;
- (void)setPrimitiveHomeAgainstValue:(int64_t)value_;

- (NSNumber*)primitiveHomeDrawn;
- (void)setPrimitiveHomeDrawn:(NSNumber*)value;

- (int64_t)primitiveHomeDrawnValue;
- (void)setPrimitiveHomeDrawnValue:(int64_t)value_;

- (NSNumber*)primitiveHomeFor;
- (void)setPrimitiveHomeFor:(NSNumber*)value;

- (int64_t)primitiveHomeForValue;
- (void)setPrimitiveHomeForValue:(int64_t)value_;

- (NSNumber*)primitiveHomeLost;
- (void)setPrimitiveHomeLost:(NSNumber*)value;

- (int64_t)primitiveHomeLostValue;
- (void)setPrimitiveHomeLostValue:(int64_t)value_;

- (NSNumber*)primitiveHomePlayed;
- (void)setPrimitiveHomePlayed:(NSNumber*)value;

- (int64_t)primitiveHomePlayedValue;
- (void)setPrimitiveHomePlayedValue:(int64_t)value_;

- (NSNumber*)primitiveHomePoints;
- (void)setPrimitiveHomePoints:(NSNumber*)value;

- (int64_t)primitiveHomePointsValue;
- (void)setPrimitiveHomePointsValue:(int64_t)value_;

- (NSNumber*)primitiveHomePosition;
- (void)setPrimitiveHomePosition:(NSNumber*)value;

- (int64_t)primitiveHomePositionValue;
- (void)setPrimitiveHomePositionValue:(int64_t)value_;

- (NSNumber*)primitiveHomeWon;
- (void)setPrimitiveHomeWon:(NSNumber*)value;

- (int64_t)primitiveHomeWonValue;
- (void)setPrimitiveHomeWonValue:(int64_t)value_;

- (NSString*)primitiveIdCompetition;
- (void)setPrimitiveIdCompetition:(NSString*)value;

- (NSString*)primitiveIdGroup;
- (void)setPrimitiveIdGroup:(NSString*)value;

- (NSString*)primitiveIdSeason;
- (void)setPrimitiveIdSeason:(NSString*)value;

- (NSString*)primitiveIdTeam;
- (void)setPrimitiveIdTeam:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveLost;
- (void)setPrimitiveLost:(NSNumber*)value;

- (int64_t)primitiveLostValue;
- (void)setPrimitiveLostValue:(int64_t)value_;

- (NSString*)primitiveMatchDay;
- (void)setPrimitiveMatchDay:(NSString*)value;

- (NSNumber*)primitivePlayed;
- (void)setPrimitivePlayed:(NSNumber*)value;

- (int64_t)primitivePlayedValue;
- (void)setPrimitivePlayedValue:(int64_t)value_;

- (NSNumber*)primitivePoints;
- (void)setPrimitivePoints:(NSNumber*)value;

- (int64_t)primitivePointsValue;
- (void)setPrimitivePointsValue:(int64_t)value_;

- (NSNumber*)primitivePosition;
- (void)setPrimitivePosition:(NSNumber*)value;

- (int64_t)primitivePositionValue;
- (void)setPrimitivePositionValue:(int64_t)value_;

- (NSNumber*)primitiveQualificationType;
- (void)setPrimitiveQualificationType:(NSNumber*)value;

- (uint16_t)primitiveQualificationTypeValue;
- (void)setPrimitiveQualificationTypeValue:(uint16_t)value_;

- (NSString*)primitiveSeasonName;
- (void)setPrimitiveSeasonName:(NSString*)value;

- (NSNumber*)primitiveStartDayPosition;
- (void)setPrimitiveStartDayPosition:(NSNumber*)value;

- (int64_t)primitiveStartDayPositionValue;
- (void)setPrimitiveStartDayPositionValue:(int64_t)value_;

- (NSString*)primitiveTeamBadgeThumbnailUrl;
- (void)setPrimitiveTeamBadgeThumbnailUrl:(NSString*)value;

- (NSString*)primitiveTeamBadgeUrl;
- (void)setPrimitiveTeamBadgeUrl:(NSString*)value;

- (NSString*)primitiveTeamName;
- (void)setPrimitiveTeamName:(NSString*)value;

- (NSNumber*)primitiveWon;
- (void)setPrimitiveWon:(NSNumber*)value;

- (int64_t)primitiveWonValue;
- (void)setPrimitiveWonValue:(int64_t)value_;

@end
