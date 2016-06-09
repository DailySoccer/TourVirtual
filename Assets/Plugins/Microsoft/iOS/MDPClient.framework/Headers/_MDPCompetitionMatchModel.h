//
//  _MDPCompetitionMatchModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPCompetitionMatchModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPCompetitionMatchModelAttributes {
	__unsafe_unretained NSString *awayTeamBadgeThumbnailUrl;
	__unsafe_unretained NSString *awayTeamBadgeUrl;
	__unsafe_unretained NSString *awayTeamGoals;
	__unsafe_unretained NSString *awayTeamName;
	__unsafe_unretained NSString *awayTeamPenaltyGoals;
	__unsafe_unretained NSString *callType;
	__unsafe_unretained NSString *competitionName;
	__unsafe_unretained NSString *date;
	__unsafe_unretained NSString *group;
	__unsafe_unretained NSString *homeTeamBadgeThumbnailUrl;
	__unsafe_unretained NSString *homeTeamBadgeUrl;
	__unsafe_unretained NSString *homeTeamGoals;
	__unsafe_unretained NSString *homeTeamName;
	__unsafe_unretained NSString *homeTeamPenaltyGoals;
	__unsafe_unretained NSString *idAwayTeam;
	__unsafe_unretained NSString *idCompetition;
	__unsafe_unretained NSString *idHomeTeam;
	__unsafe_unretained NSString *idMatch;
	__unsafe_unretained NSString *idSeason;
	__unsafe_unretained NSString *idStadium;
	__unsafe_unretained NSString *isHomeMatch;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *matchDay;
	__unsafe_unretained NSString *seasonName;
	__unsafe_unretained NSString *showBuyTickets;
	__unsafe_unretained NSString *sport;
} MDPCompetitionMatchModelAttributes;

extern const struct MDPCompetitionMatchModelRelationships {
	__unsafe_unretained NSString *channels;
	__unsafe_unretained NSString *competitionMatchRequest;
	__unsafe_unretained NSString *leg;
	__unsafe_unretained NSString *period;
	__unsafe_unretained NSString *stage;
} MDPCompetitionMatchModelRelationships;

@class MDPBroadcastChannelModel;
@class MDPCompetitionMatchRequestModel;
@class MDPKeyValueObjectModel;
@class MDPKeyValueObjectModel;
@class MDPKeyValueObjectModel;

@interface _MDPCompetitionMatchModel : NSManagedObject

@property (nonatomic, strong) NSString* awayTeamBadgeThumbnailUrl;

//- (BOOL)validateAwayTeamBadgeThumbnailUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* awayTeamBadgeUrl;

//- (BOOL)validateAwayTeamBadgeUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* awayTeamGoals;

@property (atomic) int64_t awayTeamGoalsValue;
- (int64_t)awayTeamGoalsValue;
- (void)setAwayTeamGoalsValue:(int64_t)value_;

//- (BOOL)validateAwayTeamGoals:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* awayTeamName;

//- (BOOL)validateAwayTeamName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* awayTeamPenaltyGoals;

@property (atomic) int64_t awayTeamPenaltyGoalsValue;
- (int64_t)awayTeamPenaltyGoalsValue;
- (void)setAwayTeamPenaltyGoalsValue:(int64_t)value_;

//- (BOOL)validateAwayTeamPenaltyGoals:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* callType;

@property (atomic) int16_t callTypeValue;
- (int16_t)callTypeValue;
- (void)setCallTypeValue:(int16_t)value_;

//- (BOOL)validateCallType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* competitionName;

//- (BOOL)validateCompetitionName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* date;

//- (BOOL)validateDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* group;

//- (BOOL)validateGroup:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* homeTeamBadgeThumbnailUrl;

//- (BOOL)validateHomeTeamBadgeThumbnailUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* homeTeamBadgeUrl;

//- (BOOL)validateHomeTeamBadgeUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* homeTeamGoals;

@property (atomic) int64_t homeTeamGoalsValue;
- (int64_t)homeTeamGoalsValue;
- (void)setHomeTeamGoalsValue:(int64_t)value_;

//- (BOOL)validateHomeTeamGoals:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* homeTeamName;

//- (BOOL)validateHomeTeamName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* homeTeamPenaltyGoals;

@property (atomic) int64_t homeTeamPenaltyGoalsValue;
- (int64_t)homeTeamPenaltyGoalsValue;
- (void)setHomeTeamPenaltyGoalsValue:(int64_t)value_;

//- (BOOL)validateHomeTeamPenaltyGoals:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idAwayTeam;

//- (BOOL)validateIdAwayTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idCompetition;

//- (BOOL)validateIdCompetition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idHomeTeam;

//- (BOOL)validateIdHomeTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idMatch;

//- (BOOL)validateIdMatch:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSeason;

//- (BOOL)validateIdSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idStadium;

//- (BOOL)validateIdStadium:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* isHomeMatch;

@property (atomic) BOOL isHomeMatchValue;
- (BOOL)isHomeMatchValue;
- (void)setIsHomeMatchValue:(BOOL)value_;

//- (BOOL)validateIsHomeMatch:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* matchDay;

//- (BOOL)validateMatchDay:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* seasonName;

//- (BOOL)validateSeasonName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* showBuyTickets;

@property (atomic) BOOL showBuyTicketsValue;
- (BOOL)showBuyTicketsValue;
- (void)setShowBuyTicketsValue:(BOOL)value_;

//- (BOOL)validateShowBuyTickets:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* sport;

@property (atomic) uint16_t sportValue;
- (uint16_t)sportValue;
- (void)setSportValue:(uint16_t)value_;

//- (BOOL)validateSport:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *channels;

- (NSMutableSet*)channelsSet;

@property (nonatomic, strong) NSSet *competitionMatchRequest;

- (NSMutableSet*)competitionMatchRequestSet;

@property (nonatomic, strong) MDPKeyValueObjectModel *leg;

//- (BOOL)validateLeg:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPKeyValueObjectModel *period;

//- (BOOL)validatePeriod:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPKeyValueObjectModel *stage;

//- (BOOL)validateStage:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPCompetitionMatchModel (ChannelsCoreDataGeneratedAccessors)
- (void)addChannels:(NSSet*)value_;
- (void)removeChannels:(NSSet*)value_;
- (void)addChannelsObject:(MDPBroadcastChannelModel*)value_;
- (void)removeChannelsObject:(MDPBroadcastChannelModel*)value_;
@end

@interface _MDPCompetitionMatchModel (CompetitionMatchRequestCoreDataGeneratedAccessors)
- (void)addCompetitionMatchRequest:(NSSet*)value_;
- (void)removeCompetitionMatchRequest:(NSSet*)value_;
- (void)addCompetitionMatchRequestObject:(MDPCompetitionMatchRequestModel*)value_;
- (void)removeCompetitionMatchRequestObject:(MDPCompetitionMatchRequestModel*)value_;
@end

@interface _MDPCompetitionMatchModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAwayTeamBadgeThumbnailUrl;
- (void)setPrimitiveAwayTeamBadgeThumbnailUrl:(NSString*)value;

- (NSString*)primitiveAwayTeamBadgeUrl;
- (void)setPrimitiveAwayTeamBadgeUrl:(NSString*)value;

- (NSNumber*)primitiveAwayTeamGoals;
- (void)setPrimitiveAwayTeamGoals:(NSNumber*)value;

- (int64_t)primitiveAwayTeamGoalsValue;
- (void)setPrimitiveAwayTeamGoalsValue:(int64_t)value_;

- (NSString*)primitiveAwayTeamName;
- (void)setPrimitiveAwayTeamName:(NSString*)value;

- (NSNumber*)primitiveAwayTeamPenaltyGoals;
- (void)setPrimitiveAwayTeamPenaltyGoals:(NSNumber*)value;

- (int64_t)primitiveAwayTeamPenaltyGoalsValue;
- (void)setPrimitiveAwayTeamPenaltyGoalsValue:(int64_t)value_;

- (NSNumber*)primitiveCallType;
- (void)setPrimitiveCallType:(NSNumber*)value;

- (int16_t)primitiveCallTypeValue;
- (void)setPrimitiveCallTypeValue:(int16_t)value_;

- (NSString*)primitiveCompetitionName;
- (void)setPrimitiveCompetitionName:(NSString*)value;

- (NSDate*)primitiveDate;
- (void)setPrimitiveDate:(NSDate*)value;

- (NSString*)primitiveGroup;
- (void)setPrimitiveGroup:(NSString*)value;

- (NSString*)primitiveHomeTeamBadgeThumbnailUrl;
- (void)setPrimitiveHomeTeamBadgeThumbnailUrl:(NSString*)value;

- (NSString*)primitiveHomeTeamBadgeUrl;
- (void)setPrimitiveHomeTeamBadgeUrl:(NSString*)value;

- (NSNumber*)primitiveHomeTeamGoals;
- (void)setPrimitiveHomeTeamGoals:(NSNumber*)value;

- (int64_t)primitiveHomeTeamGoalsValue;
- (void)setPrimitiveHomeTeamGoalsValue:(int64_t)value_;

- (NSString*)primitiveHomeTeamName;
- (void)setPrimitiveHomeTeamName:(NSString*)value;

- (NSNumber*)primitiveHomeTeamPenaltyGoals;
- (void)setPrimitiveHomeTeamPenaltyGoals:(NSNumber*)value;

- (int64_t)primitiveHomeTeamPenaltyGoalsValue;
- (void)setPrimitiveHomeTeamPenaltyGoalsValue:(int64_t)value_;

- (NSString*)primitiveIdAwayTeam;
- (void)setPrimitiveIdAwayTeam:(NSString*)value;

- (NSString*)primitiveIdCompetition;
- (void)setPrimitiveIdCompetition:(NSString*)value;

- (NSString*)primitiveIdHomeTeam;
- (void)setPrimitiveIdHomeTeam:(NSString*)value;

- (NSString*)primitiveIdMatch;
- (void)setPrimitiveIdMatch:(NSString*)value;

- (NSString*)primitiveIdSeason;
- (void)setPrimitiveIdSeason:(NSString*)value;

- (NSString*)primitiveIdStadium;
- (void)setPrimitiveIdStadium:(NSString*)value;

- (NSNumber*)primitiveIsHomeMatch;
- (void)setPrimitiveIsHomeMatch:(NSNumber*)value;

- (BOOL)primitiveIsHomeMatchValue;
- (void)setPrimitiveIsHomeMatchValue:(BOOL)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveMatchDay;
- (void)setPrimitiveMatchDay:(NSString*)value;

- (NSString*)primitiveSeasonName;
- (void)setPrimitiveSeasonName:(NSString*)value;

- (NSNumber*)primitiveShowBuyTickets;
- (void)setPrimitiveShowBuyTickets:(NSNumber*)value;

- (BOOL)primitiveShowBuyTicketsValue;
- (void)setPrimitiveShowBuyTicketsValue:(BOOL)value_;

- (NSNumber*)primitiveSport;
- (void)setPrimitiveSport:(NSNumber*)value;

- (uint16_t)primitiveSportValue;
- (void)setPrimitiveSportValue:(uint16_t)value_;

- (NSMutableSet*)primitiveChannels;
- (void)setPrimitiveChannels:(NSMutableSet*)value;

- (NSMutableSet*)primitiveCompetitionMatchRequest;
- (void)setPrimitiveCompetitionMatchRequest:(NSMutableSet*)value;

- (MDPKeyValueObjectModel*)primitiveLeg;
- (void)setPrimitiveLeg:(MDPKeyValueObjectModel*)value;

- (MDPKeyValueObjectModel*)primitivePeriod;
- (void)setPrimitivePeriod:(MDPKeyValueObjectModel*)value;

- (MDPKeyValueObjectModel*)primitiveStage;
- (void)setPrimitiveStage:(MDPKeyValueObjectModel*)value;

@end
