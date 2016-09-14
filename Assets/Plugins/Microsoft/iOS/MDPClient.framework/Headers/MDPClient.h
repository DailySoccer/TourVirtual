//
//  MDPClient.h
//  MDPClient
//
//  Created by Ernesto Fernández Calles on 22/12/14.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import <UIKit/UIKit.h>

//! Project version number for MDPClient.
FOUNDATION_EXPORT double MDPClientVersionNumber;

//! Project version string for MDPClient.
FOUNDATION_EXPORT const unsigned char MDPClientVersionString[];

// In this header, you should import all the public headers of your framework using statements like #import <MDPClient/PublicHeader.h>


#pragma mark - Setup Info
// Keychain Configuration neccesary for ADAL:
//      - Activate in the app Capabilities->Keychain Sharing
//      - Add keychain group with identifier "com.microsoft.adalcache"

#pragma mark - Handlers
#import "MDPClientHandler.h"


#pragma mark - Auth
#import "MDPAuthHandler.h"


#pragma mark - Log, App Insights
#import "MDPLogHandler.h"


#pragma mark - Model
#import "MDPAchievementConfigurationModel.h"
#import "MDPAchievementConfigurationTypeModel.h"
#import "MDPAchievementModel.h"
#import "MDPAdImageModel.h"
#import "MDPAdvertisementLanguageModel.h"
#import "MDPAdvertisementModel.h"
#import "MDPAppConfigurationVersionModel.h"
#import "MDPAppModel.h"
#import "MDPAssetModel.h"
#import "MDPBasketBoxscoreModel.h"
#import "MDPBasketLineUpPlayerModel.h"
#import "MDPBasketLiveMatchModel.h"
#import "MDPBasketLiveMatchPlayerStatisticsModel.h"
#import "MDPBasketLiveMatchTeamStatisticsModel.h"
#import "MDPBasketTeamDataModel.h"
#import "MDPBodyPlatformNotificationModel.h"
#import "MDPBookingModel.h"
#import "MDPBroadcastChannelModel.h"
#import "MDPCareerDetailModel.h"
#import "MDPCheckInModel.h"
#import "MDPCheckInTypeModel.h"
#import "MDPCommentModel.h"
#import "MDPCompactContentModel.h"
#import "MDPCompetitionMatchModel.h"
#import "MDPCompetitionModel.h"
#import "MDPConfigurationModel.h"
#import "MDPConfigurationTrustedClientAppModel.h"
#import "MDPContentLinkModel.h"
#import "MDPContentModel.h"
#import "MDPContentParagraphModel.h"
#import "MDPContentPlayerModel.h"
#import "MDPCountryModel.h"
#import "MDPExtendedSearchModel.h"
#import "MDPExperienceRankingModel.h"
#import "MDPExternalChallengeModel.h"
#import "MDPExternalChallengeTypeModel.h"
#import "MDPExternalIdentityModel.h"
#import "MDPFanContactModel.h"
#import "MDPFanContactExtendedModel.h"
#import "MDPFanMaxScoreModel.h"
#import "MDPFanModel.h"
#import "MDPFanOfferModel.h"
#import "MDPFanTagsModel.h"
#import "MDPFanVirtualGoodModel.h"
#import "MDPFanMaxScoreModel.h"
#import "MDPFootballLiveMatchModel.h"
#import "MDPFootballLiveMatchPlayerStatisticsModel.h"
#import "MDPFootballLiveMatchTeamStatisticsModel.h"
#import "MDPFootballMatchPlayerModel.h"
#import "MDPFootballTeamDataModel.h"
#import "MDPFriendModel.h"
#import "MDPGamificationLevelBasicInfoModel.h"
#import "MDPGamificationStatusModel.h"
#import "MDPGeoJsonPointModel.h"
#import "MDPGoalModel.h"
#import "MDPGroupModel.h"
#import "MDPGroupMemberModel.h"
#import "MDPGroupThreadModel.h"
#import "MDPHomeModel.h"
#import "MDPHonourModel.h"
#import "MDPIndexedFanModel.h"
#import "MDPIndexedGroupModel.h"
#import "MDPInvitationModel.h"
#import "MDPKeyValueObjectModel.h"
#import "MDPLanguageModel.h"
#import "MDPLiveFootBallSeasonCompetitionPlayerStatModel.h"
#import "MDPLiveFootBallSeasonCompetitionStatModel.h"
#import "MDPLiveFootBallSeasonCompetitionTeamPlayersStatModel.h"
#import "MDPLiveFootBallSeasonCompetitionTeamStatModel.h"
#import "MDPLiveFootBallSeasonPlayerStatModel.h"
#import "MDPLiveMatchTeamModel.h"
#import "MDPLiveMatchTeamStatModel.h"
#import "MDPLocaleDescriptionModel.h"
#import "MDPLocationModel.h"
#import "MDPMatchEventModel.h"
#import "MDPMatchModel.h"
#import "MDPMatchOfficialModel.h"
#import "MDPMatchStatisticModel.h"
#import "MDPMatchStatusModel.h"
#import "MDPMatchSubscriptionInformationModel.h"
#import "MDPMediaContentModel.h"
#import "MDPMenuAdvertisementModel.h"
#import "MDPMenuModel.h"
#import "MDPMessageModel.h"
#import "MDPNotificationModel.h"
#import "MDPPagedAchievementConfigurationTypeModel.h"
#import "MDPPagedAchievementsModel.h"
#import "MDPPagedAnswersModel.h"
#import "MDPPagedCheckInsModel.h"
#import "MDPPagedCheckInTypeModel.h"
#import "MDPCommentAnswerModel.h"
#import "MDPPagedCommentsModel.h"
#import "MDPPagedCompactContentModel.h"
#import "MDPPagedExternalChallengeTypeModel.h"
#import "MDPPagedFanOffersModel.h"
#import "MDPPagedFanVirtualGoodsModel.h"
#import "MDPPagedGroupsModel.h"
#import "MDPPagedGroupMembersModel.h"
#import "MDPPagedIndexedGroupsModel.h"
#import "MDPPagedMessagesModel.h"
#import "MDPPagedNotificationsModel.h"
#import "MDPPagedPenyaModel.h"
#import "MDPPagedPlatformNotificationsModel.h"
#import "MDPPagedPointsTransactionsModel.h"
#import "MDPPagedRequestJoinGroupModel.h"
#import "MDPPagedStoreProductsModel.h"
#import "MDPPagedSubscriptionConfigurationBasicInfoModel.h"
#import "MDPPagedSubscriptionConfigurationModel.h"
#import "MDPPagedSubscriptionConfigurationTypeModel.h"
#import "MDPPagedMatchSubscriptionInformationModel.h"
#import "MDPPagedTweetModel.h"
#import "MDPPagedVideosModel.h"
#import "MDPPagedVirtualGoodModel.h"
#import "MDPPagedVirtualGoodTypeModel.h"
#import "MDPPaidFanLinkedStatusModel.h"
#import "MDPPartialUpdateItemModel.h"
#import "MDPPartialUpdateModel.h"
#import "MDPPenaltyShotModel.h"
#import "MDPPlatformNotificationModel.h"
#import "MDPPlayerBasicInfoModel.h"
#import "MDPPlayerChangeModel.h"
#import "MDPPlayerModel.h"
#import "MDPPlayerStatisticModel.h"
#import "MDPPlayerStatisticValueModel.h"
#import "MDPPointsTransactionModel.h"
#import "MDPPossessionIntervalModel.h"
#import "MDPPossessionLastXModel.h"
#import "MDPPossessionModel.h"
#import "MDPPreferredPlayerItemModel.h"
#import "MDPPreferredPlayerModel.h"
#import "MDPProductItemModel.h"
#import "MDPProductPriceModel.h"
#import "MDPProfileAvatarAccessoryItemModel.h"
#import "MDPProfileAvatarItemModel.h"
#import "MDPProfileAvatarModel.h"
#import "MDPProfileAvatarUpdateableModel.h"
#import "MDPRequestJoinGroupModel.h"
#import "MDPRelatedContentModel.h"
#import "MDPResourceModel.h"
#import "MDPResourceVersionModel.h"
#import "MDPRuleConfigurationModel.h"
#import "MDPShootOutModel.h"
#import "MDPSplashModel.h"
#import "MDPStandingModel.h"
#import "MDPStateModel.h"
#import "MDPStatisticTypeModel.h"
#import "MDPScoreRankingModel.h"
#import "MDPStoreProductModel.h"
#import "MDPSubscriptionConfigurationBasicInfoModel.h"
#import "MDPSubscriptionConfigurationTypeModel.h"
#import "MDPSubscriptionModel.h"
#import "MDPSubscriptionVideoModel.h"
#import "MDPSubstitutionModel.h"
#import "MDPTagInfoModel.h"
#import "MDPTeamModel.h"
#import "MDPTeamOfficialModel.h"
#import "MDPTeamStatisticModel.h"
#import "MDPTimelineModel.h"
#import "MDPTweetEntitiesModel.h"
#import "MDPTweetHashtagModel.h"
#import "MDPTweetMediaModel.h"
#import "MDPTweetModel.h"
#import "MDPTweetSymbolModel.h"
#import "MDPTweetUserMentionsModel.h"
#import "MDPTweetUserModel.h"
#import "MDPTweetUrlModel.h"
#import "MDPUserNotificationTagModel.h"
#import "MDPVenueModel.h"
#import "MDPVideoModel.h"
#import "MDPVideoPackSearchModel.h"
#import "MDPVideoPublicationChannelModel.h"
#import "MDPVirtualGoodModel.h"
#import "MDPVirtualGoodTypeModel.h"


#pragma mark - Errors
#import "NSError+MDPError.h"


#pragma mark - Third Party
#pragma mark AFNetworking
#import "AFNetworking.h"
#import "UIKit+AFNetworking.h"




























































