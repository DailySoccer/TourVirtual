//
//  _MDPMatchModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPMatchModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPMatchModelAttributes {
	__unsafe_unretained NSString *badgeUrl;
	__unsafe_unretained NSString *city;
	__unsafe_unretained NSString *competitionName;
	__unsafe_unretained NSString *country;
	__unsafe_unretained NSString *date;
	__unsafe_unretained NSString *favorite;
	__unsafe_unretained NSString *idCompetition;
	__unsafe_unretained NSString *idGroup;
	__unsafe_unretained NSString *idMatch;
	__unsafe_unretained NSString *idSeason;
	__unsafe_unretained NSString *idSubscription;
	__unsafe_unretained NSString *isTicketSalesAllowed;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *matchDay;
	__unsafe_unretained NSString *matchType;
	__unsafe_unretained NSString *purchasable;
	__unsafe_unretained NSString *seasonName;
	__unsafe_unretained NSString *sportType;
	__unsafe_unretained NSString *stadium;
} MDPMatchModelAttributes;

extern const struct MDPMatchModelRelationships {
	__unsafe_unretained NSString *awayTeam;
	__unsafe_unretained NSString *channels;
	__unsafe_unretained NSString *content;
	__unsafe_unretained NSString *descriptionMatch;
	__unsafe_unretained NSString *homeTeam;
	__unsafe_unretained NSString *matchMemberSellMatch;
	__unsafe_unretained NSString *premiumStatistics;
	__unsafe_unretained NSString *statistics;
} MDPMatchModelRelationships;

@class MDPLiveMatchTeamModel;
@class MDPBroadcastChannelModel;
@class MDPMediaContentModel;
@class MDPLocaleDescriptionModel;
@class MDPLiveMatchTeamModel;
@class MDPMemberSellMatchModel;
@class MDPMatchStatisticModel;
@class MDPMatchStatisticModel;

@interface _MDPMatchModel : NSManagedObject

@property (nonatomic, strong) NSString* badgeUrl;

//- (BOOL)validateBadgeUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* city;

//- (BOOL)validateCity:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* competitionName;

//- (BOOL)validateCompetitionName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* country;

//- (BOOL)validateCountry:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* date;

//- (BOOL)validateDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* favorite;

@property (atomic) int64_t favoriteValue;
- (int64_t)favoriteValue;
- (void)setFavoriteValue:(int64_t)value_;

//- (BOOL)validateFavorite:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idCompetition;

//- (BOOL)validateIdCompetition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idGroup;

//- (BOOL)validateIdGroup:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idMatch;

//- (BOOL)validateIdMatch:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSeason;

//- (BOOL)validateIdSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSubscription;

//- (BOOL)validateIdSubscription:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* isTicketSalesAllowed;

@property (atomic) BOOL isTicketSalesAllowedValue;
- (BOOL)isTicketSalesAllowedValue;
- (void)setIsTicketSalesAllowedValue:(BOOL)value_;

//- (BOOL)validateIsTicketSalesAllowed:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* matchDay;

//- (BOOL)validateMatchDay:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* matchType;

@property (atomic) uint16_t matchTypeValue;
- (uint16_t)matchTypeValue;
- (void)setMatchTypeValue:(uint16_t)value_;

//- (BOOL)validateMatchType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* purchasable;

@property (atomic) BOOL purchasableValue;
- (BOOL)purchasableValue;
- (void)setPurchasableValue:(BOOL)value_;

//- (BOOL)validatePurchasable:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* seasonName;

//- (BOOL)validateSeasonName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* sportType;

@property (atomic) uint16_t sportTypeValue;
- (uint16_t)sportTypeValue;
- (void)setSportTypeValue:(uint16_t)value_;

//- (BOOL)validateSportType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* stadium;

//- (BOOL)validateStadium:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPLiveMatchTeamModel *awayTeam;

//- (BOOL)validateAwayTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *channels;

- (NSMutableSet*)channelsSet;

@property (nonatomic, strong) NSSet *content;

- (NSMutableSet*)contentSet;

@property (nonatomic, strong) NSSet *descriptionMatch;

- (NSMutableSet*)descriptionMatchSet;

@property (nonatomic, strong) MDPLiveMatchTeamModel *homeTeam;

//- (BOOL)validateHomeTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *matchMemberSellMatch;

- (NSMutableSet*)matchMemberSellMatchSet;

@property (nonatomic, strong) NSSet *premiumStatistics;

- (NSMutableSet*)premiumStatisticsSet;

@property (nonatomic, strong) NSSet *statistics;

- (NSMutableSet*)statisticsSet;

@end

@interface _MDPMatchModel (ChannelsCoreDataGeneratedAccessors)
- (void)addChannels:(NSSet*)value_;
- (void)removeChannels:(NSSet*)value_;
- (void)addChannelsObject:(MDPBroadcastChannelModel*)value_;
- (void)removeChannelsObject:(MDPBroadcastChannelModel*)value_;
@end

@interface _MDPMatchModel (ContentCoreDataGeneratedAccessors)
- (void)addContent:(NSSet*)value_;
- (void)removeContent:(NSSet*)value_;
- (void)addContentObject:(MDPMediaContentModel*)value_;
- (void)removeContentObject:(MDPMediaContentModel*)value_;
@end

@interface _MDPMatchModel (DescriptionMatchCoreDataGeneratedAccessors)
- (void)addDescriptionMatch:(NSSet*)value_;
- (void)removeDescriptionMatch:(NSSet*)value_;
- (void)addDescriptionMatchObject:(MDPLocaleDescriptionModel*)value_;
- (void)removeDescriptionMatchObject:(MDPLocaleDescriptionModel*)value_;
@end

@interface _MDPMatchModel (MatchMemberSellMatchCoreDataGeneratedAccessors)
- (void)addMatchMemberSellMatch:(NSSet*)value_;
- (void)removeMatchMemberSellMatch:(NSSet*)value_;
- (void)addMatchMemberSellMatchObject:(MDPMemberSellMatchModel*)value_;
- (void)removeMatchMemberSellMatchObject:(MDPMemberSellMatchModel*)value_;
@end

@interface _MDPMatchModel (PremiumStatisticsCoreDataGeneratedAccessors)
- (void)addPremiumStatistics:(NSSet*)value_;
- (void)removePremiumStatistics:(NSSet*)value_;
- (void)addPremiumStatisticsObject:(MDPMatchStatisticModel*)value_;
- (void)removePremiumStatisticsObject:(MDPMatchStatisticModel*)value_;
@end

@interface _MDPMatchModel (StatisticsCoreDataGeneratedAccessors)
- (void)addStatistics:(NSSet*)value_;
- (void)removeStatistics:(NSSet*)value_;
- (void)addStatisticsObject:(MDPMatchStatisticModel*)value_;
- (void)removeStatisticsObject:(MDPMatchStatisticModel*)value_;
@end

@interface _MDPMatchModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveBadgeUrl;
- (void)setPrimitiveBadgeUrl:(NSString*)value;

- (NSString*)primitiveCity;
- (void)setPrimitiveCity:(NSString*)value;

- (NSString*)primitiveCompetitionName;
- (void)setPrimitiveCompetitionName:(NSString*)value;

- (NSString*)primitiveCountry;
- (void)setPrimitiveCountry:(NSString*)value;

- (NSDate*)primitiveDate;
- (void)setPrimitiveDate:(NSDate*)value;

- (NSNumber*)primitiveFavorite;
- (void)setPrimitiveFavorite:(NSNumber*)value;

- (int64_t)primitiveFavoriteValue;
- (void)setPrimitiveFavoriteValue:(int64_t)value_;

- (NSString*)primitiveIdCompetition;
- (void)setPrimitiveIdCompetition:(NSString*)value;

- (NSString*)primitiveIdGroup;
- (void)setPrimitiveIdGroup:(NSString*)value;

- (NSString*)primitiveIdMatch;
- (void)setPrimitiveIdMatch:(NSString*)value;

- (NSString*)primitiveIdSeason;
- (void)setPrimitiveIdSeason:(NSString*)value;

- (NSString*)primitiveIdSubscription;
- (void)setPrimitiveIdSubscription:(NSString*)value;

- (NSNumber*)primitiveIsTicketSalesAllowed;
- (void)setPrimitiveIsTicketSalesAllowed:(NSNumber*)value;

- (BOOL)primitiveIsTicketSalesAllowedValue;
- (void)setPrimitiveIsTicketSalesAllowedValue:(BOOL)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveMatchDay;
- (void)setPrimitiveMatchDay:(NSString*)value;

- (NSNumber*)primitiveMatchType;
- (void)setPrimitiveMatchType:(NSNumber*)value;

- (uint16_t)primitiveMatchTypeValue;
- (void)setPrimitiveMatchTypeValue:(uint16_t)value_;

- (NSNumber*)primitivePurchasable;
- (void)setPrimitivePurchasable:(NSNumber*)value;

- (BOOL)primitivePurchasableValue;
- (void)setPrimitivePurchasableValue:(BOOL)value_;

- (NSString*)primitiveSeasonName;
- (void)setPrimitiveSeasonName:(NSString*)value;

- (NSNumber*)primitiveSportType;
- (void)setPrimitiveSportType:(NSNumber*)value;

- (uint16_t)primitiveSportTypeValue;
- (void)setPrimitiveSportTypeValue:(uint16_t)value_;

- (NSString*)primitiveStadium;
- (void)setPrimitiveStadium:(NSString*)value;

- (MDPLiveMatchTeamModel*)primitiveAwayTeam;
- (void)setPrimitiveAwayTeam:(MDPLiveMatchTeamModel*)value;

- (NSMutableSet*)primitiveChannels;
- (void)setPrimitiveChannels:(NSMutableSet*)value;

- (NSMutableSet*)primitiveContent;
- (void)setPrimitiveContent:(NSMutableSet*)value;

- (NSMutableSet*)primitiveDescriptionMatch;
- (void)setPrimitiveDescriptionMatch:(NSMutableSet*)value;

- (MDPLiveMatchTeamModel*)primitiveHomeTeam;
- (void)setPrimitiveHomeTeam:(MDPLiveMatchTeamModel*)value;

- (NSMutableSet*)primitiveMatchMemberSellMatch;
- (void)setPrimitiveMatchMemberSellMatch:(NSMutableSet*)value;

- (NSMutableSet*)primitivePremiumStatistics;
- (void)setPrimitivePremiumStatistics:(NSMutableSet*)value;

- (NSMutableSet*)primitiveStatistics;
- (void)setPrimitiveStatistics:(NSMutableSet*)value;

@end
