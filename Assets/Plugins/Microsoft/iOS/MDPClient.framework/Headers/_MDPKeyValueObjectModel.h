//
//  _MDPKeyValueObjectModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPKeyValueObjectModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPKeyValueObjectModelAttributes {
	__unsafe_unretained NSString *descriptionKeyValueObject;
	__unsafe_unretained NSString *idCompetition;
	__unsafe_unretained NSString *idKeyValueObject;
	__unsafe_unretained NSString *idSeason;
	__unsafe_unretained NSString *idTeam;
	__unsafe_unretained NSString *language;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *sportType;
} MDPKeyValueObjectModelAttributes;

extern const struct MDPKeyValueObjectModelRelationships {
	__unsafe_unretained NSString *basketLineUpPlayerPosition;
	__unsafe_unretained NSString *basketLiveMatchPeriod;
	__unsafe_unretained NSString *basketLiveMatchPlayerStatisticsPosition;
	__unsafe_unretained NSString *bookingPeriod;
	__unsafe_unretained NSString *competitionMatchLeg;
	__unsafe_unretained NSString *competitionMatchPeriod;
	__unsafe_unretained NSString *competitionMatchStage;
	__unsafe_unretained NSString *footballLiveMatchPeriod;
	__unsafe_unretained NSString *footballMatchPlayerPosition;
	__unsafe_unretained NSString *goalPeriod;
	__unsafe_unretained NSString *matchEventPeriod;
	__unsafe_unretained NSString *matchEventextEventType;
	__unsafe_unretained NSString *playerBasicInfoRealPosition;
	__unsafe_unretained NSString *playerBasicInfoRealPositionSide;
	__unsafe_unretained NSString *playerChangeRealPosition;
	__unsafe_unretained NSString *playerChangeRealPositionSide;
	__unsafe_unretained NSString *playerPosition;
	__unsafe_unretained NSString *playerRealPosition;
	__unsafe_unretained NSString *playerRealPositionSide;
	__unsafe_unretained NSString *playerStatisticPosition;
	__unsafe_unretained NSString *substitutionPeriod;
} MDPKeyValueObjectModelRelationships;

@class MDPBasketLineUpPlayerModel;
@class MDPBasketLiveMatchModel;
@class MDPBasketLiveMatchPlayerStatisticsModel;
@class MDPBookingModel;
@class MDPCompetitionMatchModel;
@class MDPCompetitionMatchModel;
@class MDPCompetitionMatchModel;
@class MDPFootballLiveMatchModel;
@class MDPFootballMatchPlayerModel;
@class MDPGoalModel;
@class MDPMatchEventModel;
@class MDPMatchEventModel;
@class MDPPlayerBasicInfoModel;
@class MDPPlayerBasicInfoModel;
@class MDPPlayerChangeModel;
@class MDPPlayerChangeModel;
@class MDPPlayerModel;
@class MDPPlayerModel;
@class MDPPlayerModel;
@class MDPPlayerStatisticModel;
@class MDPSubstitutionModel;

@interface _MDPKeyValueObjectModel : NSManagedObject

@property (nonatomic, strong) NSString* descriptionKeyValueObject;

//- (BOOL)validateDescriptionKeyValueObject:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idCompetition;

//- (BOOL)validateIdCompetition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idKeyValueObject;

//- (BOOL)validateIdKeyValueObject:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSeason;

//- (BOOL)validateIdSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idTeam;

//- (BOOL)validateIdTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* language;

//- (BOOL)validateLanguage:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* sportType;

@property (atomic) int64_t sportTypeValue;
- (int64_t)sportTypeValue;
- (void)setSportTypeValue:(int64_t)value_;

//- (BOOL)validateSportType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *basketLineUpPlayerPosition;

- (NSMutableSet*)basketLineUpPlayerPositionSet;

@property (nonatomic, strong) NSSet *basketLiveMatchPeriod;

- (NSMutableSet*)basketLiveMatchPeriodSet;

@property (nonatomic, strong) NSSet *basketLiveMatchPlayerStatisticsPosition;

- (NSMutableSet*)basketLiveMatchPlayerStatisticsPositionSet;

@property (nonatomic, strong) NSSet *bookingPeriod;

- (NSMutableSet*)bookingPeriodSet;

@property (nonatomic, strong) NSSet *competitionMatchLeg;

- (NSMutableSet*)competitionMatchLegSet;

@property (nonatomic, strong) NSSet *competitionMatchPeriod;

- (NSMutableSet*)competitionMatchPeriodSet;

@property (nonatomic, strong) NSSet *competitionMatchStage;

- (NSMutableSet*)competitionMatchStageSet;

@property (nonatomic, strong) NSSet *footballLiveMatchPeriod;

- (NSMutableSet*)footballLiveMatchPeriodSet;

@property (nonatomic, strong) NSSet *footballMatchPlayerPosition;

- (NSMutableSet*)footballMatchPlayerPositionSet;

@property (nonatomic, strong) NSSet *goalPeriod;

- (NSMutableSet*)goalPeriodSet;

@property (nonatomic, strong) NSSet *matchEventPeriod;

- (NSMutableSet*)matchEventPeriodSet;

@property (nonatomic, strong) NSSet *matchEventextEventType;

- (NSMutableSet*)matchEventextEventTypeSet;

@property (nonatomic, strong) NSSet *playerBasicInfoRealPosition;

- (NSMutableSet*)playerBasicInfoRealPositionSet;

@property (nonatomic, strong) NSSet *playerBasicInfoRealPositionSide;

- (NSMutableSet*)playerBasicInfoRealPositionSideSet;

@property (nonatomic, strong) NSSet *playerChangeRealPosition;

- (NSMutableSet*)playerChangeRealPositionSet;

@property (nonatomic, strong) NSSet *playerChangeRealPositionSide;

- (NSMutableSet*)playerChangeRealPositionSideSet;

@property (nonatomic, strong) NSSet *playerPosition;

- (NSMutableSet*)playerPositionSet;

@property (nonatomic, strong) NSSet *playerRealPosition;

- (NSMutableSet*)playerRealPositionSet;

@property (nonatomic, strong) NSSet *playerRealPositionSide;

- (NSMutableSet*)playerRealPositionSideSet;

@property (nonatomic, strong) NSSet *playerStatisticPosition;

- (NSMutableSet*)playerStatisticPositionSet;

@property (nonatomic, strong) NSSet *substitutionPeriod;

- (NSMutableSet*)substitutionPeriodSet;

@end

@interface _MDPKeyValueObjectModel (BasketLineUpPlayerPositionCoreDataGeneratedAccessors)
- (void)addBasketLineUpPlayerPosition:(NSSet*)value_;
- (void)removeBasketLineUpPlayerPosition:(NSSet*)value_;
- (void)addBasketLineUpPlayerPositionObject:(MDPBasketLineUpPlayerModel*)value_;
- (void)removeBasketLineUpPlayerPositionObject:(MDPBasketLineUpPlayerModel*)value_;
@end

@interface _MDPKeyValueObjectModel (BasketLiveMatchPeriodCoreDataGeneratedAccessors)
- (void)addBasketLiveMatchPeriod:(NSSet*)value_;
- (void)removeBasketLiveMatchPeriod:(NSSet*)value_;
- (void)addBasketLiveMatchPeriodObject:(MDPBasketLiveMatchModel*)value_;
- (void)removeBasketLiveMatchPeriodObject:(MDPBasketLiveMatchModel*)value_;
@end

@interface _MDPKeyValueObjectModel (BasketLiveMatchPlayerStatisticsPositionCoreDataGeneratedAccessors)
- (void)addBasketLiveMatchPlayerStatisticsPosition:(NSSet*)value_;
- (void)removeBasketLiveMatchPlayerStatisticsPosition:(NSSet*)value_;
- (void)addBasketLiveMatchPlayerStatisticsPositionObject:(MDPBasketLiveMatchPlayerStatisticsModel*)value_;
- (void)removeBasketLiveMatchPlayerStatisticsPositionObject:(MDPBasketLiveMatchPlayerStatisticsModel*)value_;
@end

@interface _MDPKeyValueObjectModel (BookingPeriodCoreDataGeneratedAccessors)
- (void)addBookingPeriod:(NSSet*)value_;
- (void)removeBookingPeriod:(NSSet*)value_;
- (void)addBookingPeriodObject:(MDPBookingModel*)value_;
- (void)removeBookingPeriodObject:(MDPBookingModel*)value_;
@end

@interface _MDPKeyValueObjectModel (CompetitionMatchLegCoreDataGeneratedAccessors)
- (void)addCompetitionMatchLeg:(NSSet*)value_;
- (void)removeCompetitionMatchLeg:(NSSet*)value_;
- (void)addCompetitionMatchLegObject:(MDPCompetitionMatchModel*)value_;
- (void)removeCompetitionMatchLegObject:(MDPCompetitionMatchModel*)value_;
@end

@interface _MDPKeyValueObjectModel (CompetitionMatchPeriodCoreDataGeneratedAccessors)
- (void)addCompetitionMatchPeriod:(NSSet*)value_;
- (void)removeCompetitionMatchPeriod:(NSSet*)value_;
- (void)addCompetitionMatchPeriodObject:(MDPCompetitionMatchModel*)value_;
- (void)removeCompetitionMatchPeriodObject:(MDPCompetitionMatchModel*)value_;
@end

@interface _MDPKeyValueObjectModel (CompetitionMatchStageCoreDataGeneratedAccessors)
- (void)addCompetitionMatchStage:(NSSet*)value_;
- (void)removeCompetitionMatchStage:(NSSet*)value_;
- (void)addCompetitionMatchStageObject:(MDPCompetitionMatchModel*)value_;
- (void)removeCompetitionMatchStageObject:(MDPCompetitionMatchModel*)value_;
@end

@interface _MDPKeyValueObjectModel (FootballLiveMatchPeriodCoreDataGeneratedAccessors)
- (void)addFootballLiveMatchPeriod:(NSSet*)value_;
- (void)removeFootballLiveMatchPeriod:(NSSet*)value_;
- (void)addFootballLiveMatchPeriodObject:(MDPFootballLiveMatchModel*)value_;
- (void)removeFootballLiveMatchPeriodObject:(MDPFootballLiveMatchModel*)value_;
@end

@interface _MDPKeyValueObjectModel (FootballMatchPlayerPositionCoreDataGeneratedAccessors)
- (void)addFootballMatchPlayerPosition:(NSSet*)value_;
- (void)removeFootballMatchPlayerPosition:(NSSet*)value_;
- (void)addFootballMatchPlayerPositionObject:(MDPFootballMatchPlayerModel*)value_;
- (void)removeFootballMatchPlayerPositionObject:(MDPFootballMatchPlayerModel*)value_;
@end

@interface _MDPKeyValueObjectModel (GoalPeriodCoreDataGeneratedAccessors)
- (void)addGoalPeriod:(NSSet*)value_;
- (void)removeGoalPeriod:(NSSet*)value_;
- (void)addGoalPeriodObject:(MDPGoalModel*)value_;
- (void)removeGoalPeriodObject:(MDPGoalModel*)value_;
@end

@interface _MDPKeyValueObjectModel (MatchEventPeriodCoreDataGeneratedAccessors)
- (void)addMatchEventPeriod:(NSSet*)value_;
- (void)removeMatchEventPeriod:(NSSet*)value_;
- (void)addMatchEventPeriodObject:(MDPMatchEventModel*)value_;
- (void)removeMatchEventPeriodObject:(MDPMatchEventModel*)value_;
@end

@interface _MDPKeyValueObjectModel (MatchEventextEventTypeCoreDataGeneratedAccessors)
- (void)addMatchEventextEventType:(NSSet*)value_;
- (void)removeMatchEventextEventType:(NSSet*)value_;
- (void)addMatchEventextEventTypeObject:(MDPMatchEventModel*)value_;
- (void)removeMatchEventextEventTypeObject:(MDPMatchEventModel*)value_;
@end

@interface _MDPKeyValueObjectModel (PlayerBasicInfoRealPositionCoreDataGeneratedAccessors)
- (void)addPlayerBasicInfoRealPosition:(NSSet*)value_;
- (void)removePlayerBasicInfoRealPosition:(NSSet*)value_;
- (void)addPlayerBasicInfoRealPositionObject:(MDPPlayerBasicInfoModel*)value_;
- (void)removePlayerBasicInfoRealPositionObject:(MDPPlayerBasicInfoModel*)value_;
@end

@interface _MDPKeyValueObjectModel (PlayerBasicInfoRealPositionSideCoreDataGeneratedAccessors)
- (void)addPlayerBasicInfoRealPositionSide:(NSSet*)value_;
- (void)removePlayerBasicInfoRealPositionSide:(NSSet*)value_;
- (void)addPlayerBasicInfoRealPositionSideObject:(MDPPlayerBasicInfoModel*)value_;
- (void)removePlayerBasicInfoRealPositionSideObject:(MDPPlayerBasicInfoModel*)value_;
@end

@interface _MDPKeyValueObjectModel (PlayerChangeRealPositionCoreDataGeneratedAccessors)
- (void)addPlayerChangeRealPosition:(NSSet*)value_;
- (void)removePlayerChangeRealPosition:(NSSet*)value_;
- (void)addPlayerChangeRealPositionObject:(MDPPlayerChangeModel*)value_;
- (void)removePlayerChangeRealPositionObject:(MDPPlayerChangeModel*)value_;
@end

@interface _MDPKeyValueObjectModel (PlayerChangeRealPositionSideCoreDataGeneratedAccessors)
- (void)addPlayerChangeRealPositionSide:(NSSet*)value_;
- (void)removePlayerChangeRealPositionSide:(NSSet*)value_;
- (void)addPlayerChangeRealPositionSideObject:(MDPPlayerChangeModel*)value_;
- (void)removePlayerChangeRealPositionSideObject:(MDPPlayerChangeModel*)value_;
@end

@interface _MDPKeyValueObjectModel (PlayerPositionCoreDataGeneratedAccessors)
- (void)addPlayerPosition:(NSSet*)value_;
- (void)removePlayerPosition:(NSSet*)value_;
- (void)addPlayerPositionObject:(MDPPlayerModel*)value_;
- (void)removePlayerPositionObject:(MDPPlayerModel*)value_;
@end

@interface _MDPKeyValueObjectModel (PlayerRealPositionCoreDataGeneratedAccessors)
- (void)addPlayerRealPosition:(NSSet*)value_;
- (void)removePlayerRealPosition:(NSSet*)value_;
- (void)addPlayerRealPositionObject:(MDPPlayerModel*)value_;
- (void)removePlayerRealPositionObject:(MDPPlayerModel*)value_;
@end

@interface _MDPKeyValueObjectModel (PlayerRealPositionSideCoreDataGeneratedAccessors)
- (void)addPlayerRealPositionSide:(NSSet*)value_;
- (void)removePlayerRealPositionSide:(NSSet*)value_;
- (void)addPlayerRealPositionSideObject:(MDPPlayerModel*)value_;
- (void)removePlayerRealPositionSideObject:(MDPPlayerModel*)value_;
@end

@interface _MDPKeyValueObjectModel (PlayerStatisticPositionCoreDataGeneratedAccessors)
- (void)addPlayerStatisticPosition:(NSSet*)value_;
- (void)removePlayerStatisticPosition:(NSSet*)value_;
- (void)addPlayerStatisticPositionObject:(MDPPlayerStatisticModel*)value_;
- (void)removePlayerStatisticPositionObject:(MDPPlayerStatisticModel*)value_;
@end

@interface _MDPKeyValueObjectModel (SubstitutionPeriodCoreDataGeneratedAccessors)
- (void)addSubstitutionPeriod:(NSSet*)value_;
- (void)removeSubstitutionPeriod:(NSSet*)value_;
- (void)addSubstitutionPeriodObject:(MDPSubstitutionModel*)value_;
- (void)removeSubstitutionPeriodObject:(MDPSubstitutionModel*)value_;
@end

@interface _MDPKeyValueObjectModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveDescriptionKeyValueObject;
- (void)setPrimitiveDescriptionKeyValueObject:(NSString*)value;

- (NSString*)primitiveIdCompetition;
- (void)setPrimitiveIdCompetition:(NSString*)value;

- (NSString*)primitiveIdKeyValueObject;
- (void)setPrimitiveIdKeyValueObject:(NSString*)value;

- (NSString*)primitiveIdSeason;
- (void)setPrimitiveIdSeason:(NSString*)value;

- (NSString*)primitiveIdTeam;
- (void)setPrimitiveIdTeam:(NSString*)value;

- (NSString*)primitiveLanguage;
- (void)setPrimitiveLanguage:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveSportType;
- (void)setPrimitiveSportType:(NSNumber*)value;

- (int64_t)primitiveSportTypeValue;
- (void)setPrimitiveSportTypeValue:(int64_t)value_;

- (NSMutableSet*)primitiveBasketLineUpPlayerPosition;
- (void)setPrimitiveBasketLineUpPlayerPosition:(NSMutableSet*)value;

- (NSMutableSet*)primitiveBasketLiveMatchPeriod;
- (void)setPrimitiveBasketLiveMatchPeriod:(NSMutableSet*)value;

- (NSMutableSet*)primitiveBasketLiveMatchPlayerStatisticsPosition;
- (void)setPrimitiveBasketLiveMatchPlayerStatisticsPosition:(NSMutableSet*)value;

- (NSMutableSet*)primitiveBookingPeriod;
- (void)setPrimitiveBookingPeriod:(NSMutableSet*)value;

- (NSMutableSet*)primitiveCompetitionMatchLeg;
- (void)setPrimitiveCompetitionMatchLeg:(NSMutableSet*)value;

- (NSMutableSet*)primitiveCompetitionMatchPeriod;
- (void)setPrimitiveCompetitionMatchPeriod:(NSMutableSet*)value;

- (NSMutableSet*)primitiveCompetitionMatchStage;
- (void)setPrimitiveCompetitionMatchStage:(NSMutableSet*)value;

- (NSMutableSet*)primitiveFootballLiveMatchPeriod;
- (void)setPrimitiveFootballLiveMatchPeriod:(NSMutableSet*)value;

- (NSMutableSet*)primitiveFootballMatchPlayerPosition;
- (void)setPrimitiveFootballMatchPlayerPosition:(NSMutableSet*)value;

- (NSMutableSet*)primitiveGoalPeriod;
- (void)setPrimitiveGoalPeriod:(NSMutableSet*)value;

- (NSMutableSet*)primitiveMatchEventPeriod;
- (void)setPrimitiveMatchEventPeriod:(NSMutableSet*)value;

- (NSMutableSet*)primitiveMatchEventextEventType;
- (void)setPrimitiveMatchEventextEventType:(NSMutableSet*)value;

- (NSMutableSet*)primitivePlayerBasicInfoRealPosition;
- (void)setPrimitivePlayerBasicInfoRealPosition:(NSMutableSet*)value;

- (NSMutableSet*)primitivePlayerBasicInfoRealPositionSide;
- (void)setPrimitivePlayerBasicInfoRealPositionSide:(NSMutableSet*)value;

- (NSMutableSet*)primitivePlayerChangeRealPosition;
- (void)setPrimitivePlayerChangeRealPosition:(NSMutableSet*)value;

- (NSMutableSet*)primitivePlayerChangeRealPositionSide;
- (void)setPrimitivePlayerChangeRealPositionSide:(NSMutableSet*)value;

- (NSMutableSet*)primitivePlayerPosition;
- (void)setPrimitivePlayerPosition:(NSMutableSet*)value;

- (NSMutableSet*)primitivePlayerRealPosition;
- (void)setPrimitivePlayerRealPosition:(NSMutableSet*)value;

- (NSMutableSet*)primitivePlayerRealPositionSide;
- (void)setPrimitivePlayerRealPositionSide:(NSMutableSet*)value;

- (NSMutableSet*)primitivePlayerStatisticPosition;
- (void)setPrimitivePlayerStatisticPosition:(NSMutableSet*)value;

- (NSMutableSet*)primitiveSubstitutionPeriod;
- (void)setPrimitiveSubstitutionPeriod:(NSMutableSet*)value;

@end
