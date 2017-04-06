//
//  MDPCompetitionMatchModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPCompetitionMatchModel.h"

#pragma mark Call Type
typedef NS_ENUM(NSInteger, MDPCompetitionMatchModelCallType) {
    MDPCompetitionMatchModelCallTypeCalendar                       = 1,
    MDPCompetitionMatchModelCallTypeNextMatch                      = 2,
    MDPCompetitionMatchModelCallTypePreviousMatch                  = 3,
    MDPCompetitionMatchModelCallTypeListOfMatchOfACompetition      = 4,
    MDPCompetitionMatchModelCallTypeCalendarBetweenDates           = 5,
    MDPCompetitionMatchModelCallTypeCalendarLastPlayedMatches      = 6,
    MDPCompetitionMatchModelCallTypeCalendarHeadToHeadMathes       = 7,
    MDPCompetitionMatchModelCallTypeCalendarPreviousAndNextMatches = 8,
} ;


#pragma mark Sport Type
typedef NS_ENUM(NSInteger, MDPCompetitionMatchModelSportType) {
    MDPCompetitionMatchModelSportTypeFootball   = 1,
    MDPCompetitionMatchModelSportTypeBasket   = 2
} ;


#pragma mark - Period idKeyValueObject
#define kFinishedMatchFootballPeriodId            @"124"  // Full time
#define kFinishedMatchBasketPeriodId              @"207"  // Post match


#pragma mark - Interface
@interface MDPCompetitionMatchModel : _MDPCompetitionMatchModel

+ (instancetype)competitionMatchWithIdSeason:(NSString *)idSeason idCompetition:(NSString *)idCompetition idMatch:(NSString *)idMatch managedObjectContext:(NSManagedObjectContext *)context;


+ (instancetype)insertIfNotExistsCompetitionMatchWithCallType:(MDPCompetitionMatchModelCallType)callType
                                                   dictionary:(NSDictionary *)dictionary
                                         managedObjectContext:(NSManagedObjectContext *)context;

#pragma mark - Returns the competitionMatchModel where date is between the first day of the previous month to "date" and the end day of the following month to "date"
+ (NSFetchedResultsController *)fetchMatchesByRangeWithDate:(NSDate *)date
                                                     idTeam:(NSString *)idTeam
                                                  sportType:(MDPCompetitionMatchModelSportType)sportType
                                                    country:(NSString *)country
                                       managedObjectContext:(NSManagedObjectContext *)context
                                                   delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

- (BOOL)isStartedMatch;

- (BOOL)isPreMatch;

- (BOOL)isFinishedMatchWithSport:(uint)sport;


#pragma mark - Return the previous matches to date. The date value is now ([NSDate date]) if date is nil
+ (NSArray *)previousMatchesWithArray:(NSArray *)matches comparingWithDate:(NSDate *)date;


#pragma mark - Return the next matches to date.  The date value is now ([NSDate date]) if date is nil
+  (NSArray *)nextMatchesWithArray:(NSArray *)matches comparingWithDate:(NSDate *)date;

@end
